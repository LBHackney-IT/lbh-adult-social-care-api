using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces
{
    public interface IUsersGateway
    {
        public Task<AppUserDomain> GetAsync(Guid userId);

        public Task<PagedList<AppUserDomain>> GetUsersWithRoles(Guid[] roles, AppUserListQueryParameters queryParams);

        public Task<bool> DeleteAsync(Guid userId);
        Task<IEnumerable<UsersMinimalDomain>> GetUsers(RolesEnum rolesType);
        Task<IEnumerable<UsersMinimalDomain>> GetUsers();
    }
}
