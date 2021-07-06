using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
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
            _databaseContext.ServiceUsers.Remove(new User
            { Id = userId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<User> GetAsync(Guid userId)
        {
            return await _databaseContext.ServiceUsers
                .Include(item => item.Role)
                .FirstOrDefaultAsync(item => item.Id == userId).ConfigureAwait(false);
        }

        public async Task<User> UpsertAsync(User user)
        {
            User userToUpdate = await _databaseContext.ServiceUsers
                .Include(item => item.Role)
                .FirstOrDefaultAsync(item => item.HackneyId == user.HackneyId).ConfigureAwait(false);
            if (userToUpdate == null)
            {
                userToUpdate = new User();
                await _databaseContext.ServiceUsers.AddAsync(userToUpdate).ConfigureAwait(false);
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.MiddleName = user.MiddleName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.HackneyId = user.HackneyId;
                userToUpdate.AddressLine1 = user.AddressLine1;
                userToUpdate.AddressLine2 = user.AddressLine2;
                userToUpdate.AddressLine3 = user.AddressLine3;
                userToUpdate.Town = user.Town;
                userToUpdate.County = user.County;
                userToUpdate.PostCode = user.PostCode;
                userToUpdate.RoleId = user.RoleId;
                userToUpdate.CreatorId = user.CreatorId;
                userToUpdate.UpdatorId = user.UpdatorId;
                userToUpdate.DateUpdated = user.DateUpdated;
            }
            else
            {
                throw new ApiException($"This record already exist Hackney Id: {user.HackneyId}");
            }
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return userToUpdate;
        }
    }
}
