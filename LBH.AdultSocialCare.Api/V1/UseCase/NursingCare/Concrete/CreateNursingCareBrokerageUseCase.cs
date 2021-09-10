using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class CreateNursingCareBrokerageUseCase : ICreateNursingCareBrokerageUseCase
    {
        private readonly IUpsertFundedNursingCareUseCase _upsertFundedNursingCareUseCase;
        private readonly IChangeStatusNursingCarePackageUseCase _changeStatusNursingCarePackageUseCase;
        private readonly INursingCareBrokerageGateway _nursingCareBrokerageGateway;
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;
        private readonly ICareChargesGateway _careChargesGateway;
        private readonly IPackageCareChargeGateway _packageCareChargeGateway;

        public CreateNursingCareBrokerageUseCase(
            IUpsertFundedNursingCareUseCase upsertFundedNursingCareUseCase,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase,
            INursingCareBrokerageGateway nursingCareBrokerageGateway,
            INursingCarePackageGateway nursingCarePackageGateway,
            ITransactionManager transactionManager,
            IMapper mapper, ICareChargesGateway careChargesGateway, IPackageCareChargeGateway packageCareChargeGateway)
        {
            _upsertFundedNursingCareUseCase = upsertFundedNursingCareUseCase;
            _changeStatusNursingCarePackageUseCase = changeStatusNursingCarePackageUseCase;
            _nursingCareBrokerageGateway = nursingCareBrokerageGateway;
            _nursingCarePackageGateway = nursingCarePackageGateway;
            _transactionManager = transactionManager;
            _mapper = mapper;
            _careChargesGateway = careChargesGateway;
            _packageCareChargeGateway = packageCareChargeGateway;
        }

        public async Task<NursingCareBrokerageInfoResponse> ExecuteAsync(NursingCareBrokerageInfoCreationDomain brokerageInfoCreationDomain)
        {
            switch (brokerageInfoCreationDomain.HasCareCharges)
            {
                case true when brokerageInfoCreationDomain.CareChargeSettings == null:
                    throw new ApiException($"Package is selected to have care charges and no settings provided",
                        StatusCodes.Status422UnprocessableEntity);
                case true when brokerageInfoCreationDomain.CareChargeSettings.ClaimedBy == PackageCostClaimersConstants.Hackney && string.IsNullOrEmpty(brokerageInfoCreationDomain.CareChargeSettings.CollectorReason):
                    throw new ApiException(
                        $"When care charges for a package are set to be reclaimed by hackney, please provide a reason",
                        StatusCodes.Status422UnprocessableEntity);
            }

            // Check nursing care package exists
            var nursingCarePackageFromDb = await _nursingCarePackageGateway
                .CheckNursingCarePackageExists(brokerageInfoCreationDomain.NursingCarePackageId).ConfigureAwait(false);

            // If S117 no care charges
            if (nursingCarePackageFromDb.IsThisUserUnderS117 && brokerageInfoCreationDomain.HasCareCharges)
            {
                throw new ApiException(
                    $"Service user with id {nursingCarePackageFromDb.ClientId} is under S117. Care charges not allowed.",
                    StatusCodes.Status422UnprocessableEntity);
            }

            var brokerage = await _nursingCareBrokerageGateway.GetAsync(brokerageInfoCreationDomain.NursingCarePackageId).ConfigureAwait(false);

            if (brokerage.NursingCareBrokerageId != Guid.Empty)
            {
                throw new ApiException($"Brokerage information for nursing care package with id {brokerageInfoCreationDomain.NursingCarePackageId} already exists", StatusCodes.Status409Conflict);
            }

            await using var transaction = await _transactionManager.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                var brokerageInfoDomain = await CreateBrokerageInfoAsync(brokerageInfoCreationDomain).ConfigureAwait(false);

                await UpdatePackageAsync(nursingCarePackageFromDb, brokerageInfoCreationDomain).ConfigureAwait(false);
                await ApprovePackageForBrokerageAsync(brokerageInfoCreationDomain.NursingCarePackageId).ConfigureAwait(false);
                await UpsertFundingNursingCareAsync(brokerageInfoCreationDomain).ConfigureAwait(false);

                if (brokerageInfoCreationDomain.HasCareCharges)
                {
                    await CreateProvisionalCareChargeAmountsAsync(nursingCarePackageFromDb.ClientId, brokerageInfoCreationDomain.SupplierId, nursingCarePackageFromDb.Id, brokerageInfoCreationDomain.CareChargeSettings.ClaimedBy, brokerageInfoCreationDomain.CareChargeSettings.CollectorReason, brokerageInfoCreationDomain.StartDate, brokerageInfoCreationDomain.EndDate).ConfigureAwait(false);
                }

                await transaction.CommitAsync().ConfigureAwait(false);

                return brokerageInfoDomain.ToResponse();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                throw;
            }
        }

        private async Task UpdatePackageAsync(NursingCarePackagePlainDomain packageDomain, NursingCareBrokerageInfoCreationDomain brokerageInfoCreationDomain)
        {
            // brokers are prohibited to change package start date, so it can come empty, but shouldn't be reset
            // packageDomain.StartDate = packageDomain.StartDate;
            packageDomain.EndDate = brokerageInfoCreationDomain.EndDate;

            packageDomain.StageId = brokerageInfoCreationDomain.StageId;
            packageDomain.SupplierId = brokerageInfoCreationDomain.SupplierId;

            var packageForUpdateDomain = _mapper.Map<NursingCarePackageForUpdateDomain>(packageDomain);

            await _nursingCarePackageGateway.UpdateAsync(packageForUpdateDomain).ConfigureAwait(false);
        }

        private async Task<NursingCareBrokerageInfoDomain> CreateBrokerageInfoAsync(NursingCareBrokerageInfoCreationDomain brokerageInfoCreationDomain)
        {
            var brokerageInfoEntity = brokerageInfoCreationDomain.ToDb();

            var result = await _nursingCareBrokerageGateway
                .CreateAsync(brokerageInfoEntity)
                .ConfigureAwait(false);

            return result;
        }

        private async Task UpsertFundingNursingCareAsync(NursingCareBrokerageInfoCreationDomain brokerageInfoCreationDomain)
        {
            await _upsertFundedNursingCareUseCase
                .UpsertAsync(
                    brokerageInfoCreationDomain.NursingCarePackageId,
                    brokerageInfoCreationDomain.SupplierId,
                    brokerageInfoCreationDomain.FundedNursingCareCollectorId)
                .ConfigureAwait(false);
        }

        private async Task ApprovePackageForBrokerageAsync(Guid packageId)
        {
            //Change status of package
            await _changeStatusNursingCarePackageUseCase
                .UpdateAsync(packageId, ApprovalHistoryConstants.ApprovedForBrokerageId)
                .ConfigureAwait(false);
        }

        private async Task CreateProvisionalCareChargeAmountsAsync(Guid serviceUserId, int supplierId, Guid nursingCarePackageId, int collectorId, string claimCollectorReason, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            // Get provisional amount for this client
            var provisionalAmount = await _careChargesGateway.GetUsingServiceUserIdAsync(serviceUserId).ConfigureAwait(false);
            if (provisionalAmount == null) return;

            var packageCareCharge = new PackageCareCharge
            {
                PackageId = nursingCarePackageId,
                PackageTypeId = PackageTypesConstants.NursingCarePackageId,
                IsProvisional = true,
                ServiceUserId = serviceUserId,
                SupplierId = supplierId,
                CareChargeElements = new List<CareChargeElement>()
                {
                    new CareChargeElement
                    {
                        StatusId = (int) CareChargeElementStatusEnum.Active,
                        TypeId = (int) CareChargeElementTypeEnum.Provisional,
                        ClaimCollectorId = collectorId,
                        ClaimReasons = claimCollectorReason,
                        Name = "Provisional nursing care SU contribution",
                        Amount = provisionalAmount.Amount,
                        StartDate = startDate,
                        EndDate = endDate,
                        PaidUpTo = null,
                        PreviousPaidUpTo = null
                    }
                }
            };

            // Create package care charge
            await _packageCareChargeGateway.CreateAsync(packageCareCharge).ConfigureAwait(false);
        }
    }
}
