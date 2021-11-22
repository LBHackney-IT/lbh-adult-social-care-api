using LBH.AdultSocialCare.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces
{
    public interface IUserRolesGateway
    {
        Task<IEnumerable<AppUserRole>> GetUserRolesAsync(Guid userId, bool trackChanges = false);

        void RemoveUserRoles(IEnumerable<AppUserRole> userRoles);
    }
}
