using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class UpdateResidentialCarePackageUseCase : IUpdateResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;

        public UpdateResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _gateway = residentialCarePackageGateway;
        }

        public async Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForUpdateDomain residentialCarePackageForUpdate)
        {
            var residentialCarePackageDomain = await _gateway.UpdateAsync(residentialCarePackageForUpdate).ConfigureAwait(false);
            return residentialCarePackageDomain.ToResponse();
        }
    }
}
