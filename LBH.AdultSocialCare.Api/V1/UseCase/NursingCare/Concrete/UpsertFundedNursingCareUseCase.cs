using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class UpsertFundedNursingCareUseCase : IUpsertFundedNursingCareUseCase
    {
        private readonly IFundedNursingCaseGateway _gateway;

        public UpsertFundedNursingCareUseCase(IFundedNursingCaseGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<FundedNursingCareDomain> UpsertAsync(Guid packageId, int? collectorId)
        {
            if (collectorId is null)
            {
                await _gateway.DeleteFundedNursingCare(packageId).ConfigureAwait(false);
                return null;
            }

            var fundedNursingCare = new FundedNursingCareDomain
            {
                NursingCarePackageId = packageId,
                CollectorId = collectorId.Value,
                ReclaimTargetInstitutionId = ReclaimTargetInstitutionConstants.Ccg
            };

            return await _gateway
                .UpsertFundedNursingCase(fundedNursingCare)
                .ConfigureAwait(false);
        }
    }
}
