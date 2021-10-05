using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IClientsGateway
    {
        public Task<Client> UpsertAsync(Client client);

        public Task<Client> GetAsync(Guid clientId);

        public Task<bool> DeleteAsync(Guid clientId);

        public Task<PagedList<ClientsDomain>> ListAsync(RequestParameters parameters, string clientName);

        public Task<IEnumerable<ClientMinimalDomain>> GetClientMinimalInList(List<Guid> clientIds);

        Task<ClientsDomain> GetRandomAsync();
    }
}
