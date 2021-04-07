using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
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
            if (clientEntity == null) return clients = null;
            else
            {
                clients = ClientsFactory.ToDomain(clientEntity);
            }
            return clients;
        }
    }
}
