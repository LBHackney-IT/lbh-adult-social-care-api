using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete
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
