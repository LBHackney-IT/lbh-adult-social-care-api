using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class UpsertFundedNursingCareUseCase : IUpsertFundedNursingCareUseCase
    {
        private readonly IFundedNursingCareGateway _fncGateway;
        private readonly ISupplierGateway _supplierGateway;

        public UpsertFundedNursingCareUseCase(IFundedNursingCareGateway fncGateway, ISupplierGateway supplierGateway)
        {
            _fncGateway = fncGateway;
            _supplierGateway = supplierGateway;
        }

        public async Task<FundedNursingCareDomain> UpsertAsync(Guid packageId, int? supplierId, int? collectorId)
        {
            // If no FNC is defined for this package remove previous FNC is any
            if (collectorId is null)
            {
                await _fncGateway.DeleteFundedNursingCareAsync(packageId).ConfigureAwait(false);
                return null;
            }

            await SetDefaultFundedNursingCareCollectorIdToSupplier(supplierId, collectorId).ConfigureAwait(false);

            var fundedNursingCare = new FundedNursingCareDomain
            {
                NursingCarePackageId = packageId,
                CollectorId = collectorId.Value,
                ReclaimTargetInstitutionId = ReclaimTargetInstitutionConstants.Ccg
            };

            return await _fncGateway
                .UpsertFundedNursingCaseAsync(fundedNursingCare)
                .ConfigureAwait(false);
        }

        private async Task SetDefaultFundedNursingCareCollectorIdToSupplier(int? supplierId, int? collectorId)
        {
            if (supplierId.HasValue)
            {
                var supplier = await _supplierGateway
                    .GetAsync(supplierId.Value)
                    .ConfigureAwait(false);

                supplier.FundedNursingCareCollectorId = collectorId;

                await _supplierGateway
                    .UpdateAsync(supplier)
                    .ConfigureAwait(false);
            }
        }
    }
}
