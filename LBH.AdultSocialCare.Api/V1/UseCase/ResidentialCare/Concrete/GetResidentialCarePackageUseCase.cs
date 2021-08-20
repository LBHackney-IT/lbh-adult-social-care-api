using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
{
    public class GetResidentialCarePackageUseCase : IGetResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;

        public GetResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _gateway = residentialCarePackageGateway;
        }

        public async Task<ResidentialCarePackageResponse> GetAsync(Guid residentialCarePackageId)
        {
            var packageDomain = await _gateway.GetAsync(residentialCarePackageId).ConfigureAwait(false);
            return packageDomain.ToResponse();
        }
    }
}
