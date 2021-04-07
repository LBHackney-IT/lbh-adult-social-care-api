using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetClientsUseCase : IGetClientsUseCase
    {
        private readonly IClientsGateway _gateway;
        public GetClientsUseCase(IClientsGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<ClientsDomain> GetAsync(Guid clientId)
        {
            var usersEntity = await _gateway.GetAsync(clientId).ConfigureAwait(false);
            return ClientsFactory.ToDomain(usersEntity);
        }
    }
}
