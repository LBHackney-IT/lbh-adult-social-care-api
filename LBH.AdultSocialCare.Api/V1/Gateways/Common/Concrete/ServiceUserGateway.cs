using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class ServiceUserGateway : IServiceUserGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ServiceUserGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CreateAsync(Client client)
        {
            var entry = await _databaseContext.Clients.AddAsync(client);
            try
            {
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save client to database");
            }
        }

        public async Task<int> GetServiceUserCountAsync(int hackneyId)
        {
            return await _databaseContext.Clients
                .Where(c => c.HackneyId.Equals(hackneyId))
                .CountAsync();
        }

        public async Task<ClientsDomain> GetAsync(int hackneyId)
        {
            var client = await _databaseContext.Clients
                .Where(c => c.HackneyId.Equals(hackneyId))
                .SingleOrDefaultAsync();

            return client.ToDomain();
        }
    }
}
