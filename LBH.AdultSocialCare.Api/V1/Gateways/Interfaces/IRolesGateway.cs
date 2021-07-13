using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IRolesGateway
    {
        public Task<Role> UpsertAsync(Role role);

        public Task<Role> GetAsync(int roleId);

        public Task<IList<Role>> ListAsync();

        public Task<bool> DeleteAsync(int roleId);
    }
}
