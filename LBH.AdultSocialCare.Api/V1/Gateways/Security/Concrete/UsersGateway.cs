using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Security.Concrete
{
    public class UsersGateway : IUsersGateway
    {
        private readonly DatabaseContext _databaseContext;

        public UsersGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<PagedList<AppUserDomain>> GetUsersWithRoles(Guid[] roles, AppUserListQueryParameters queryParams)
        {
            var userIds = await _databaseContext.UserRoles.Where(ur => roles.Contains(ur.RoleId)).Select(ur => ur.UserId).Distinct().ToListAsync();
            var users = await _databaseContext.Users.Where(u => userIds.Contains(u.Id))
                .FilterAppUsers(queryParams.searchTerm)
                .Select(u => new AppUserDomain
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .ToListAsync();
            var userCount = await _databaseContext.Users.Where(u => userIds.Contains(u.Id))
                .FilterAppUsers(queryParams.searchTerm)
                .CountAsync();

            var pagedUsers = PagedList<AppUserDomain>.ToPagedList(users, userCount, queryParams.PageNumber, queryParams.PageSize);
            return pagedUsers;
        }

        public async Task<bool> DeleteAsync(Guid userId)
        {
            _databaseContext.Users.Remove(new User
            { Id = userId });
            var isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<AppUserDomain> GetAsync(Guid userId)
        {
            var user = await _databaseContext.Users
                .FirstOrDefaultAsync(item => item.Id == userId).ConfigureAwait(false);
            return user?.ToDomain();
        }

        public async Task<IEnumerable<UsersMinimalDomain>> GetUsers(RolesEnum rolesType)
        {
            var roleId = await _databaseContext.Roles
                .Where(r => r.Name.Equals(rolesType.ToString()))
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            return await _databaseContext.Roles
                .Join(_databaseContext.UserRoles,
                    role => role.Id,
                    userRole => userRole.RoleId,
                    (role, userRole) => new { RoleId = role.Id, userRole.UserId })
                .Join(_databaseContext.Users,
                    userRole => userRole.UserId,
                    user => user.Id,
                    (userRole, user) => new { userRole.RoleId, user.Name, user.Id })
                .Where(userInfo => userInfo.RoleId == roleId)
                .Select(userInfo => new UsersMinimalDomain { Id = userInfo.Id, UserName = userInfo.Name })
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<UsersMinimalDomain>> GetUsers()
        {
            return await _databaseContext.Users
                .Select(u => new UsersMinimalDomain
                {
                    Id = u.Id,
                    UserName = u.Name
                })
                .ToListAsync();
        }
    }
}
