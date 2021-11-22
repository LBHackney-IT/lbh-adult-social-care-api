using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces
{
    public interface IRolesGateway
    {
        public Task<RolesDomain> GetAsync(Guid roleId);

        public Task<IList<RolesDomain>> ListAsync();
    }
}
