using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
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
            _databaseContext.Clients.Remove(new Clients() { Id = clientId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<Clients> GetAsync(Guid clientId)
        {
            return await _databaseContext.Clients.FirstOrDefaultAsync(item => item.Id == clientId).ConfigureAwait(false);
        }

        public async Task<Clients> UpsertAsync(Clients clients)
        {
            Clients clientsToUpdate = await _databaseContext.Clients.FirstOrDefaultAsync(item => item.HackneyId == clients.HackneyId).ConfigureAwait(false);
            if (clientsToUpdate == null)
            {
                clientsToUpdate = new Clients();
                await _databaseContext.Clients.AddAsync(clientsToUpdate).ConfigureAwait(false);
                clientsToUpdate.FirstName = clients.FirstName;
                clientsToUpdate.MiddleName = clients.MiddleName;
                clientsToUpdate.LastName = clients.LastName;
                clientsToUpdate.DateOfBirth = clients.DateOfBirth;
                clientsToUpdate.HackneyId = clients.HackneyId;
                clientsToUpdate.AddressLine1 = clients.AddressLine1;
                clientsToUpdate.AddressLine2 = clients.AddressLine2;
                clientsToUpdate.AddressLine3 = clients.AddressLine3;
                clientsToUpdate.Town = clients.Town;
                clientsToUpdate.County = clients.County;
                clientsToUpdate.PostCode = clients.PostCode;
                clientsToUpdate.CreatorId = clients.CreatorId;
                clientsToUpdate.DateCreated = clients.DateCreated;
                clientsToUpdate.UpdatorId = clients.UpdatorId;
                clientsToUpdate.DateUpdated = clients.DateUpdated;
            }
            else
            {
                throw new ErrorException($"This record already exist Hackney Id: {clients.HackneyId}");
            }
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess ? clientsToUpdate : null;
        }
    }
}
