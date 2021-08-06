using LBH.AdultSocialCare.Api.V1.Domain.ClientDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases
{
    public class UpsertClientsUseCase : IUpsertClientsUseCase
    {
        private readonly IClientsGateway _gateway;

        public UpsertClientsUseCase(IClientsGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<ClientsDomain> ExecuteAsync(ClientsDomain clients)
        {
            var clientEntity = clients.ToEntity();
            clientEntity = await _gateway.UpsertAsync(clientEntity).ConfigureAwait(false);

            if (clientEntity == null)
            {
                return null;
            }

            clients = clientEntity.ToDomain();

            return clients;
        }
    }
}
