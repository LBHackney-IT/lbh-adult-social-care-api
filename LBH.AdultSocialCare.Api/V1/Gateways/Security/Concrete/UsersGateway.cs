using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Security.Concrete
{
    public class UsersGateway : IUsersGateway
    {
        private readonly DatabaseContext _databaseContext;

        public UsersGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid userId)
        {
            _databaseContext.Users.Remove(new User
            { Id = userId });
            var isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<UsersDomain> GetAsync(Guid userId)
        {
            var user = await _databaseContext.Users
                .FirstOrDefaultAsync(item => item.Id == userId).ConfigureAwait(false);
            return user?.ToDomain();
        }
    }
}