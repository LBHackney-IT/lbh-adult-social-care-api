using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
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
