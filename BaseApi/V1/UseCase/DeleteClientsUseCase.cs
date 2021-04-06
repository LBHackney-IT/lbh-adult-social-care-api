using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class DeleteClientsUseCase : IDeleteClientsUseCase
    {
        private readonly IClientsGateway _gateway;
        public DeleteClientsUseCase(IClientsGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<bool> DeleteAsync(Guid clientId)
        {
            return await _gateway.DeleteAsync(clientId).ConfigureAwait(false);
        }
    }
}
