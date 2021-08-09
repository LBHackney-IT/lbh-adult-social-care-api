using LBH.AdultSocialCare.Api.V1.Domain.ClientDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IClientsGateway
    {
        public Task<Client> UpsertAsync(Client client);

        public Task<Client> GetAsync(Guid clientId);

        public Task<bool> DeleteAsync(Guid clientId);

        public Task<IEnumerable<ClientMinimalDomain>> GetClientMinimalInList(List<Guid> clientIds);
    }
}
