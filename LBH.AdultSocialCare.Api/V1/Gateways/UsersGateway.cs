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
            _databaseContext.ServiceUsers.Remove(new ServiceUser
            { Id = userId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<ServiceUser> GetAsync(Guid userId)
        {
            return await _databaseContext.ServiceUsers
                .Include(item => item.Role)
                .FirstOrDefaultAsync(item => item.Id == userId).ConfigureAwait(false);
        }

        public async Task<ServiceUser> UpsertAsync(ServiceUser serviceUser)
        {
            ServiceUser serviceUserToUpdate = await _databaseContext.ServiceUsers
                .Include(item => item.Role)
                .FirstOrDefaultAsync(item => item.HackneyId == serviceUser.HackneyId).ConfigureAwait(false);
            if (serviceUserToUpdate == null)
            {
                serviceUserToUpdate = new ServiceUser();
                await _databaseContext.ServiceUsers.AddAsync(serviceUserToUpdate).ConfigureAwait(false);
                serviceUserToUpdate.FirstName = serviceUser.FirstName;
                serviceUserToUpdate.MiddleName = serviceUser.MiddleName;
                serviceUserToUpdate.LastName = serviceUser.LastName;
                serviceUserToUpdate.HackneyId = serviceUser.HackneyId;
                serviceUserToUpdate.AddressLine1 = serviceUser.AddressLine1;
                serviceUserToUpdate.AddressLine2 = serviceUser.AddressLine2;
                serviceUserToUpdate.AddressLine3 = serviceUser.AddressLine3;
                serviceUserToUpdate.Town = serviceUser.Town;
                serviceUserToUpdate.County = serviceUser.County;
                serviceUserToUpdate.PostCode = serviceUser.PostCode;
                serviceUserToUpdate.RoleId = serviceUser.RoleId;
                serviceUserToUpdate.CreatorId = serviceUser.CreatorId;
                serviceUserToUpdate.UpdatorId = serviceUser.UpdatorId;
                serviceUserToUpdate.DateUpdated = serviceUser.DateUpdated;
            }
            else
            {
                throw new ApiException($"This record already exist Hackney Id: {serviceUser.HackneyId}");
            }
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return serviceUserToUpdate;
        }
    }
}
