using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.ClientDomains;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

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
            _databaseContext.Clients.Remove(new Client
            {
                Id = clientId
            });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }

        public async Task<PagedList<ClientsDomain>> ListAsync(RequestParameters parameters, string clientName)
        {
            var clientsCount = await _databaseContext.Clients
                .FilterByName(clientName)
                .CountAsync().ConfigureAwait(false);

            var clientsPage = await _databaseContext.Clients
                .FilterByName(clientName)
                .GetPage(parameters.PageNumber, parameters.PageSize)
                .ToListAsync().ConfigureAwait(false);

            return PagedList<ClientsDomain>
                .ToPagedList(clientsPage?.ToDomain(), clientsCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<IEnumerable<ClientMinimalDomain>> GetClientMinimalInList(List<Guid> clientIds)
        {
            return await _databaseContext.Clients.Where(c => clientIds.Contains(c.Id))
                .Select(c => new ClientMinimalDomain
                {
                    ClientId = c.Id,
                    ClientName = $"{c.FirstName ?? ""} {c.MiddleName ?? ""} {c.LastName ?? ""}"
                }).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Client> GetAsync(Guid clientId)
        {
            return await _databaseContext.Clients.FirstOrDefaultAsync(item => item.Id == clientId).ConfigureAwait(false);
        }

        public async Task<Client> UpsertAsync(Client client)
        {
            Client clientToUpdate = await _databaseContext.Clients
                .FirstOrDefaultAsync(item => item.HackneyId == client.HackneyId)
                .ConfigureAwait(false);

            if (clientToUpdate == null)
            {
                clientToUpdate = new Client();
                await _databaseContext.Clients.AddAsync(clientToUpdate).ConfigureAwait(false);
                clientToUpdate.FirstName = client.FirstName;
                clientToUpdate.MiddleName = client.MiddleName;
                clientToUpdate.LastName = client.LastName;
                clientToUpdate.DateOfBirth = client.DateOfBirth;
                clientToUpdate.HackneyId = client.HackneyId;
                clientToUpdate.AddressLine1 = client.AddressLine1;
                clientToUpdate.AddressLine2 = client.AddressLine2;
                clientToUpdate.AddressLine3 = client.AddressLine3;
                clientToUpdate.Town = client.Town;
                clientToUpdate.County = client.County;
                clientToUpdate.PostCode = client.PostCode;
                clientToUpdate.CreatorId = client.CreatorId;
                clientToUpdate.UpdatorId = client.UpdatorId;
            }
            else
            {
                throw new ApiException($"This record already exist Hackney Id: {client.HackneyId}");
            }

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? clientToUpdate
                : null;
        }

        public async Task<ClientsDomain> GetRandomAsync()
        {
            int total = await _databaseContext.Clients.CountAsync().ConfigureAwait(false);
            Random r = new Random();
            int offset = r.Next(0, total);

            var result = await _databaseContext.Clients.Skip(offset).FirstOrDefaultAsync().ConfigureAwait(false);
            return result?.ToDomain();
        }
    }
}
