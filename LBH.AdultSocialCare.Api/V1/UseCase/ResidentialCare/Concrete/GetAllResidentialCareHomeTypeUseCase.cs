using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
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
