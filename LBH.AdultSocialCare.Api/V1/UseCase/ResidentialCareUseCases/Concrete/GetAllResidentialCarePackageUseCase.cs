using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class GetAllResidentialCarePackageUseCase : IGetAllResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;

        public GetAllResidentialCarePackageUseCase(IResidentialCarePackageGateway nursingCareAdditionalNeedsGateway)
        {
            _gateway = nursingCareAdditionalNeedsGateway;
        }

        public async Task<IEnumerable<ResidentialCarePackageResponse>> GetAllAsync()
        {
            var result = await _gateway.ListAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
