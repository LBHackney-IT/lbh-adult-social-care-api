using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
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
