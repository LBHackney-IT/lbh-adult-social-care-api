using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    // TODO: Merge with IServiceUser gateway
    public interface IClientsGateway
    {
        public Task<ServiceUser> UpsertAsync(ServiceUser serviceUser);

        public Task<ServiceUser> GetAsync(Guid clientId);

        public Task<bool> DeleteAsync(Guid clientId);

        public Task<IEnumerable<ServiceUserMinimalDomain>> GetClientMinimalInList(List<Guid> clientIds);
    }
}
