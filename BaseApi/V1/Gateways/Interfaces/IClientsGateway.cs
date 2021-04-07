using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways.Interfaces
{
    public interface IClientsGateway
    {
        public Task<Clients> UpsertAsync(Clients clients);

        public Task<Clients> GetAsync(Guid clientId);

        public Task<bool> DeleteAsync(Guid clientId);
    }
}
