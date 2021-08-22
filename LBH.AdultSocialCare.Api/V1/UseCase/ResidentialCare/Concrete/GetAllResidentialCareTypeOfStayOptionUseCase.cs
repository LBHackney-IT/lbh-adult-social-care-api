using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
{
    public class GetAllResidentialCareTypeOfStayOptionUseCase : IGetAllResidentialCareTypeOfStayOptionUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;

        public GetAllResidentialCareTypeOfStayOptionUseCase(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _gateway = residentialCarePackageGateway;
        }

        public async Task<IEnumerable<ResidentialCareTypeOfStayOptionResponse>> GetAllAsync()
        {
            var result = await _gateway.GetListOfResidentialCareTypeOfStayOptionAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
