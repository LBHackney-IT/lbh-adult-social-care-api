using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete
{
    public class GetAllClientsUseCase : IGetAllClientsUseCase
    {
        private readonly IClientsGateway _clientsGateway;

        public GetAllClientsUseCase(IClientsGateway clientsGateway)
        {
            _clientsGateway = clientsGateway;
        }

        public async Task<PagedResponse<ClientsResponse>> GetAllAsync(RequestParameters parameters, string clientName)
        {
            var result = await _clientsGateway.ListAsync(parameters, clientName).ConfigureAwait(false);

            return new PagedResponse<ClientsResponse>
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
