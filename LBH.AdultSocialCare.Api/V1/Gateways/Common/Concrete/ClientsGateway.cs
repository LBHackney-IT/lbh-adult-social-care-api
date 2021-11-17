using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class ClientsGateway : IClientsGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ClientsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid clientId)
        {
            _databaseContext.ServiceUsers.Remove(new ServiceUser
            {
                Id = clientId
            });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }

        public async Task<IEnumerable<ServiceUserMinimalDomain>> GetClientMinimalInList(List<Guid> clientIds)
        {
            return await _databaseContext.ServiceUsers.Where(c => clientIds.Contains(c.Id))
                .Select(c => new ServiceUserMinimalDomain
                {
                    Id = c.Id,
                    Name = $"{c.FirstName ?? ""} {c.MiddleName ?? ""} {c.LastName ?? ""}"
                }).ToListAsync().ConfigureAwait(false);
        }

        // TODO: Move to ServiceUserGateway and reconcile with 'get by hackney id' method
        public async Task<ServiceUser> GetAsync(Guid clientId)
        {
            return await _databaseContext.ServiceUsers.FirstOrDefaultAsync(item => item.Id == clientId).ConfigureAwait(false);
        }

        public async Task<ServiceUser> UpsertAsync(ServiceUser serviceUser)
        {
            ServiceUser serviceUserToUpdate = await _databaseContext.ServiceUsers
                .FirstOrDefaultAsync(item => item.HackneyId == serviceUser.HackneyId)
                .ConfigureAwait(false);

            if (serviceUserToUpdate == null)
            {
                serviceUserToUpdate = new ServiceUser();
                await _databaseContext.ServiceUsers.AddAsync(serviceUserToUpdate).ConfigureAwait(false);
                serviceUserToUpdate.FirstName = serviceUser.FirstName;
                serviceUserToUpdate.MiddleName = serviceUser.MiddleName;
                serviceUserToUpdate.LastName = serviceUser.LastName;
                serviceUserToUpdate.DateOfBirth = serviceUser.DateOfBirth;
                serviceUserToUpdate.HackneyId = serviceUser.HackneyId;
                serviceUserToUpdate.AddressLine1 = serviceUser.AddressLine1;
                serviceUserToUpdate.AddressLine2 = serviceUser.AddressLine2;
                serviceUserToUpdate.AddressLine3 = serviceUser.AddressLine3;
                serviceUserToUpdate.Town = serviceUser.Town;
                serviceUserToUpdate.County = serviceUser.County;
                serviceUserToUpdate.PostCode = serviceUser.PostCode;
                serviceUserToUpdate.CreatorId = serviceUser.CreatorId;
                serviceUserToUpdate.UpdaterId = serviceUser.UpdaterId;
            }
            else
            {
                throw new ApiException($"This record already exist Hackney Id: {serviceUser.HackneyId}");
            }

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? serviceUserToUpdate
                : null;
        }
    }
}
