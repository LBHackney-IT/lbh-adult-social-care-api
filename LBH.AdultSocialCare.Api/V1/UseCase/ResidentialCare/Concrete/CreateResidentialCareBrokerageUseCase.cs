using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
{
    public class CreateResidentialCareBrokerageUseCase : ICreateResidentialCareBrokerageUseCase
    {
        private readonly IResidentialCareBrokerageGateway _residentialCareBrokerageGateway;
        private readonly IResidentialCarePackageGateway _residentialCarePackageGateway;
        private readonly IMapper _mapper;
        private readonly IChangeDatesOfResidentialCarePackageUseCase _changeDatesOfResidentialCarePackageUseCase;
        private readonly ICareChargesGateway _careChargesGateway;
        private readonly IPackageCareChargeGateway _packageCareChargeGateway;
        private readonly ITransactionManager _transactionManager;
        private readonly IChangeStatusResidentialCarePackageUseCase _changeStatusResidentialCarePackageUseCase;

        public CreateResidentialCareBrokerageUseCase(IResidentialCareBrokerageGateway residentialCareBrokerageGateway,
            IResidentialCarePackageGateway residentialCarePackageGateway,
            IMapper mapper, IChangeDatesOfResidentialCarePackageUseCase changeDatesOfResidentialCarePackageUseCase,
            ICareChargesGateway careChargesGateway, IPackageCareChargeGateway packageCareChargeGateway, ITransactionManager transactionManager,
            IChangeStatusResidentialCarePackageUseCase changeStatusResidentialCarePackageUseCase)
        {
            _residentialCareBrokerageGateway = residentialCareBrokerageGateway;
            _residentialCarePackageGateway = residentialCarePackageGateway;
            _mapper = mapper;
            _changeDatesOfResidentialCarePackageUseCase = changeDatesOfResidentialCarePackageUseCase;
            _careChargesGateway = careChargesGateway;
            _packageCareChargeGateway = packageCareChargeGateway;
            _transactionManager = transactionManager;
            _changeStatusResidentialCarePackageUseCase = changeStatusResidentialCarePackageUseCase;
        }

        public async Task<ResidentialCareBrokerageInfoResponse> ExecuteAsync(ResidentialCareBrokerageForCreationDomain brokerageForCreationDomain)
        {
            var (residentialCarePackageFromDb, brokerageInfo) =
                await ValidateBrokerageInfoAsync(brokerageForCreationDomain).ConfigureAwait(false);

            await using var transaction = await _transactionManager.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                // Create brokerage info
                var brokerageInfoDomain = await CreateBrokerageInfo(brokerageForCreationDomain).ConfigureAwait(false);

                // Update residential care package. Stage, supplier and end date
                await UpdatePackageAsync(residentialCarePackageFromDb, brokerageForCreationDomain).ConfigureAwait(false);

                // Update package status
                await ChangePackageStatusAsync(brokerageForCreationDomain.ResidentialCarePackageId).ConfigureAwait(false);

                // Create care charges if selected
                if (brokerageForCreationDomain.HasCareCharges)
                {
                    await CreateProvisionalCareChargeAmountsAsync(residentialCarePackageFromDb.ClientId, brokerageForCreationDomain.SupplierId, residentialCarePackageFromDb.Id, brokerageForCreationDomain.CareChargeSettings.ClaimedBy, brokerageForCreationDomain.CareChargeSettings.CollectorReason, brokerageForCreationDomain.StartDate, brokerageForCreationDomain.EndDate).ConfigureAwait(false);
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

        private async Task<(ResidentialCarePackagePlainDomain, ResidentialCareBrokerageInfoDomain)>
            ValidateBrokerageInfoAsync(ResidentialCareBrokerageForCreationDomain brokerageForCreationDomain)
        {
            switch (brokerageForCreationDomain.HasCareCharges)
            {
                case true when brokerageForCreationDomain.CareChargeSettings == null:
                    throw new ApiException($"Package is selected to have care charges and no settings provided",
                        StatusCodes.Status422UnprocessableEntity);
                case true when brokerageForCreationDomain.CareChargeSettings.ClaimedBy == PackageCostClaimersConstants.Hackney && string.IsNullOrEmpty(brokerageForCreationDomain.CareChargeSettings.CollectorReason):
                    throw new ApiException(
                        $"When care charges for a package are set to be reclaimed by hackney, please provide a reason",
                        StatusCodes.Status422UnprocessableEntity);
            }

            // Check residential care package exists
            var residentialCarePackageFromDb = await _residentialCarePackageGateway.CheckResidentialCarePackageExistsAsync(brokerageForCreationDomain.ResidentialCarePackageId).ConfigureAwait(false);

            // If S117 no care charges
            if (residentialCarePackageFromDb.IsThisUserUnderS117 && brokerageForCreationDomain.HasCareCharges)
            {
                throw new ApiException(
                    $"Service user with id {residentialCarePackageFromDb.ClientId} is under S117. Care charges not allowed.",
                    StatusCodes.Status422UnprocessableEntity);
            }

            // Check if residential care brokerage info already created and reject this request
            var brokerageInfo = await _residentialCareBrokerageGateway.GetAsync(brokerageForCreationDomain.ResidentialCarePackageId).ConfigureAwait(false);

            if (brokerageInfo.ResidentialCareBrokerageId != Guid.Empty)
            {
                throw new ApiException($"Brokerage information for residential care package with id {brokerageForCreationDomain.ResidentialCarePackageId} already exists", StatusCodes.Status409Conflict);
            }

            return (residentialCarePackageFromDb, brokerageInfo);
        }

        private async Task<ResidentialCareBrokerageInfoDomain> CreateBrokerageInfo(
            ResidentialCareBrokerageForCreationDomain brokerageForCreationDomain)
        {
            var residentialCareBrokerageInfoEntity = brokerageForCreationDomain.ToDb();
            var result = await _residentialCareBrokerageGateway.CreateAsync(residentialCareBrokerageInfoEntity).ConfigureAwait(false);
            return result;
        }

        private async Task UpdatePackageAsync(ResidentialCarePackagePlainDomain packagePlainDomain,
            ResidentialCareBrokerageForCreationDomain brokerageForCreationDomain)
        {
            // brokers are prohibited to change package start date, so it can come empty, but shouldn't be reset
            packagePlainDomain.StageId = brokerageForCreationDomain.StageId;
            packagePlainDomain.EndDate = brokerageForCreationDomain.EndDate;
            packagePlainDomain.SupplierId = brokerageForCreationDomain.SupplierId;

            var packageForUpdateDomain = _mapper.Map<ResidentialCarePackageForUpdateDomain>(packagePlainDomain);

            await _residentialCarePackageGateway.UpdateAsync(packageForUpdateDomain).ConfigureAwait(false);
        }

        private async Task ChangePackageStatusAsync(Guid packageId)
        {
            //Change status of package
            await _changeStatusResidentialCarePackageUseCase
                .UpdateAsync(packageId, ApprovalHistoryConstants.ApprovedForBrokerageId)
                .ConfigureAwait(false);
        }

        private async Task CreateProvisionalCareChargeAmountsAsync(Guid serviceUserId, int supplierId, Guid residentialCarePackageId, int collectorId, string claimCollectorReason, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            // Get provisional amount for this client
            var provisionalAmount = await _careChargesGateway.GetUsingServiceUserIdAsync(serviceUserId).ConfigureAwait(false);
            if (provisionalAmount == null) return;

            var packageCareCharge = new PackageCareCharge
            {
                PackageId = residentialCarePackageId,
                PackageTypeId = PackageTypesConstants.ResidentialCarePackageId,
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
                        Name = "Provisional residential care SU contribution",
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
