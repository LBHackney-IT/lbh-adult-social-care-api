using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IRolesGateway
    {
        public Task<Roles> UpsertAsync(Roles roles);

        public Task<Roles> GetAsync(Guid roleId);

        public Task<IList<Roles>> ListAsync();

        public Task<bool> DeleteAsync(Guid roleId);
    }
}
