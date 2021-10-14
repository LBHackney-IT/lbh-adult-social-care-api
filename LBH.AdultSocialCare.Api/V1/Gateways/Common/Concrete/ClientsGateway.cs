using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

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

        public async Task<PagedList<ClientsDomain>> ListAsync(RequestParameters parameters, string clientName)
        {
            try
            {
                var clientsCount = await _databaseContext.ServiceUsers
                    .FilterByName(clientName)
                    .CountAsync().ConfigureAwait(false);

                var clientsPage = await _databaseContext.ServiceUsers
                    .FilterByName(clientName)
                    .GetPage(parameters.PageNumber, parameters.PageSize)
                    .ToListAsync().ConfigureAwait(false);

                return PagedList<ClientsDomain>
                    .ToPagedList(clientsPage?.ToDomain(), clientsCount, parameters.PageNumber, parameters.PageSize);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<ClientMinimalDomain>> GetClientMinimalInList(List<Guid> clientIds)
        {
            return await _databaseContext.ServiceUsers.Where(c => clientIds.Contains(c.Id))
                .Select(c => new ClientMinimalDomain
                {
                    ClientId = c.Id,
                    ClientName = $"{c.FirstName ?? ""} {c.MiddleName ?? ""} {c.LastName ?? ""}"
                }).ToListAsync().ConfigureAwait(false);
        }

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

        public async Task<ClientsDomain> GetRandomAsync()
        {
            int total = await _databaseContext.ServiceUsers.CountAsync().ConfigureAwait(false);
            Random r = new Random();
            int offset = r.Next(0, total);

            var result = await _databaseContext.ServiceUsers.Skip(offset).FirstOrDefaultAsync().ConfigureAwait(false);
            return result?.ToDomain();
        }
    }
}
