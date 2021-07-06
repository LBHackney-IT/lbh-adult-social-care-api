using LBH.AdultSocialCare.Api.V1.Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IRolesGateway
    {
        public Task<RolesDomain> UpsertAsync(IdentityRole role);

        public Task<RolesDomain> GetAsync(string roleId);

        public Task<IList<RolesDomain>> ListAsync();

        public Task<bool> DeleteAsync(string roleId);
    }
}
