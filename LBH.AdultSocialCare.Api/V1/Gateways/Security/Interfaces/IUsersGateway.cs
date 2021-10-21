using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

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
