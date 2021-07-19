using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class GetAllResidentialCareHomeTypeUseCase : IGetAllResidentialCareHomeTypeUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;

        public GetAllResidentialCareHomeTypeUseCase(IResidentialCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<IEnumerable<TypeOfResidentialCareHomeResponse>> GetAllAsync()
        {
            var result = await _gateway.GetListOfTypeOfResidentialCareHomeAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
