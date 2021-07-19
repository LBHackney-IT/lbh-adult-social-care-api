using LBH.AdultSocialCare.Api.V1.Domain.RoleDomains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IRolesGateway
    {
        public Task<RolesDomain> UpsertAsync(Role role);

        public Task<RolesDomain> GetAsync(Guid roleId);

        public Task<IList<RolesDomain>> ListAsync();

        public Task<bool> DeleteAsync(Guid roleId);
    }
}
