using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
