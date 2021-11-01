using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete
{
    public class GetServiceUsersUseCase : IGetServiceUsersUseCase
    {
        private readonly IServiceUserGateway _serviceUserGateway;

        public GetServiceUsersUseCase(IServiceUserGateway serviceUserGateway)
        {
            _serviceUserGateway = serviceUserGateway;
        }

        public async Task<PagedResponse<ServiceUserResponse>> GetAllAsync(RequestParameters parameters, string clientName)
        {
            var result = await _serviceUserGateway.GetAllAsync(parameters, clientName);

            return new PagedResponse<ServiceUserResponse>
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
