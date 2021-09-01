using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

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

        public CreateNursingCareBrokerageUseCase(
            IUpsertFundedNursingCareUseCase upsertFundedNursingCareUseCase,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase,
            INursingCareBrokerageGateway nursingCareBrokerageGateway,
            INursingCarePackageGateway nursingCarePackageGateway,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            _upsertFundedNursingCareUseCase = upsertFundedNursingCareUseCase;
            _changeStatusNursingCarePackageUseCase = changeStatusNursingCarePackageUseCase;
            _nursingCareBrokerageGateway = nursingCareBrokerageGateway;
            _nursingCarePackageGateway = nursingCarePackageGateway;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        public async Task<NursingCareBrokerageInfoResponse> ExecuteAsync(NursingCareBrokerageInfoCreationDomain brokerageInfoCreationDomain)
        {
            var brokerage = await _nursingCareBrokerageGateway.GetAsync(brokerageInfoCreationDomain.NursingCarePackageId).ConfigureAwait(false);

            if (brokerage.NursingCareBrokerageId != Guid.Empty)
            {
                throw new ApiException($"A brokerage for nursing care package {brokerageInfoCreationDomain.NursingCarePackageId} already exists");
            }

            await using var transaction = await _transactionManager.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                var brokerageInfoDomain = await CreateBrokerageInfoAsync(brokerageInfoCreationDomain).ConfigureAwait(false);

                await UpdatePackageAsync(brokerageInfoCreationDomain).ConfigureAwait(false);
                await ApprovePackageForBrokerageAsync(brokerageInfoCreationDomain.NursingCarePackageId).ConfigureAwait(false);
                await UpsertFundingNursingCareAsync(brokerageInfoCreationDomain).ConfigureAwait(false);

                await transaction.CommitAsync().ConfigureAwait(false);

                return brokerageInfoDomain.ToResponse();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                throw;
            }
        }

        private async Task UpdatePackageAsync(NursingCareBrokerageInfoCreationDomain brokerageInfoCreationDomain)
        {
            var packageDomain = await _nursingCarePackageGateway
                .GetAsync(brokerageInfoCreationDomain.NursingCarePackageId)
                .ConfigureAwait(false);

            packageDomain.StageId = brokerageInfoCreationDomain.StageId;
            packageDomain.SupplierId = brokerageInfoCreationDomain.SupplierId;

            // brokers are prohibited to change start date, so it can come empty, but shouldn't be reset
            packageDomain.StartDate = brokerageInfoCreationDomain.StartDate ?? packageDomain.StartDate;
            packageDomain.EndDate = brokerageInfoCreationDomain.EndDate;

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
    }
}
