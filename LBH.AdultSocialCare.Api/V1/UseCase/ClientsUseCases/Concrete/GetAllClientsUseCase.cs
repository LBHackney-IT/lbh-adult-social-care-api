using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases.Concrete
{
    public class GetAllClientsUseCase : IGetAllClientsUseCase
    {
        private readonly IClientsGateway _clientsGateway;

        public GetAllClientsUseCase(IClientsGateway clientsGateway)
        {
            _clientsGateway = clientsGateway;
        }

        public async Task<PagedResponse<ClientsResponse>> GetAllAsync(RequestParameters parameters)
        {
            var result = await _clientsGateway.ListAsync(parameters).ConfigureAwait(false);

            return new PagedResponse<ClientsResponse>
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
