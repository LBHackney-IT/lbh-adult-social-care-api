using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class ChangeStatusResidentialCarePackageUseCase : IChangeStatusResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;
        public ChangeStatusResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _gateway = residentialCarePackageGateway;
        }

        public async Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId)
        {
            var residentialCarePackageDomain = await _gateway.ChangeStatusAsync(residentialCarePackageId, statusId).ConfigureAwait(false);
            return residentialCarePackageDomain.ToResponse();
        }
    }
}
