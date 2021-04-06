using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure;
using BaseApi.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways
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
            _databaseContext.Users.Remove(new Users() { Id = userId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<Users> GetAsync(Guid userId)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(item => item.Id == userId).ConfigureAwait(false);
        }

        public async Task<Users> UpsertAsync(Users users)
        {
            Users usersToUpdate = await _databaseContext.Users.FirstOrDefaultAsync(item => item.HackneyId == users.HackneyId).ConfigureAwait(false);
            if (usersToUpdate == null)
            {
                usersToUpdate = new Users();
                await _databaseContext.Users.AddAsync(usersToUpdate).ConfigureAwait(false);
                usersToUpdate.FirstName = users.FirstName;
                usersToUpdate.MiddleName = users.MiddleName;
                usersToUpdate.LastName = users.LastName;
                usersToUpdate.HackneyId = users.HackneyId;
                usersToUpdate.AddressLine1 = users.AddressLine1;
                usersToUpdate.AddressLine2 = users.AddressLine2;
                usersToUpdate.AddressLine3 = users.AddressLine3;
                usersToUpdate.Town = users.Town;
                usersToUpdate.County = users.County;
                usersToUpdate.PostCode = users.PostCode;
                usersToUpdate.RoleId = users.RoleId;
                usersToUpdate.Roles = await _databaseContext.Roles.FirstOrDefaultAsync(item => item.Id == users.RoleId).ConfigureAwait(false);
                usersToUpdate.CreatorId = users.CreatorId;
                usersToUpdate.DateCreated = users.DateCreated;
                usersToUpdate.UpdatorId = users.UpdatorId;
                usersToUpdate.DateUpdated = users.DateUpdated;
                usersToUpdate.Success = true;
            }
            else
            {
                usersToUpdate.Message = $"This record already exist Hackney Id: {users.HackneyId}";
                usersToUpdate.Success = false;
            }
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return usersToUpdate;
        }
    }
}
