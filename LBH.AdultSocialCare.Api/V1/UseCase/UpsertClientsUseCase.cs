using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
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
            Clients clientEntity = ClientsFactory.ToEntity(clients);
            clientEntity = await _gateway.UpsertAsync(clientEntity).ConfigureAwait(false);

            if (clientEntity == null)
            {
                return null;
            }

            clients = ClientsFactory.ToDomain(clientEntity);

            return clients;
        }

    }

}
