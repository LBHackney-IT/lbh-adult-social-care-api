using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class ServiceUserGateway : IServiceUserGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ServiceUserGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CreateAsync(ServiceUser serviceUser)
        {
            var entry = await _databaseContext.ServiceUsers.AddAsync(serviceUser);
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
            return await _databaseContext.ServiceUsers
                .Where(c => c.HackneyId.Equals(hackneyId))
                .CountAsync();
        }

        public async Task<ServiceUserDomain> GetAsync(int hackneyId)
        {
            var client = await _databaseContext.ServiceUsers
                .Where(c => c.HackneyId.Equals(hackneyId))
                .SingleOrDefaultAsync();

            return client.ToDomain();
        }

        public async Task<ServiceUser> GetUsingIdAsync(Guid serviceUserId)
        {
            var serviceUser = await _databaseContext.ServiceUsers.Where(su => su.Id.Equals(serviceUserId))
                .SingleOrDefaultAsync();
            return serviceUser;
        }

        public async Task<PagedList<ServiceUserDomain>> GetAllAsync(RequestParameters parameters, string serviceUserName)
        {
            var serviceUsersCount = await _databaseContext.ServiceUsers
                .FilterByName(serviceUserName)
                .CountAsync().ConfigureAwait(false);

            var serviceUsers = await _databaseContext.ServiceUsers
                .FilterByName(serviceUserName)
                .GetPage(parameters.PageNumber, parameters.PageSize)
                .ToListAsync().ConfigureAwait(false);

            return PagedList<ServiceUserDomain>
                .ToPagedList(serviceUsers?.ToDomain(), serviceUsersCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<ServiceUserDomain> GetRandomAsync()
        {
            var total = await _databaseContext.ServiceUsers.CountAsync();
            var random = new Random();
            var offset = random.Next(0, total);

            var result = await _databaseContext.ServiceUsers.Skip(offset).FirstOrDefaultAsync();
            return result?.ToDomain();
        }

        public async Task<PagedList<ServiceUserDomain>> GetServiceUserInformation(ServiceUserQueryParameters queryParameters)
        {
            var serviceUsers = await _databaseContext.ServiceUsers
                .FilterServiceUser(queryParameters.FirstName, queryParameters.LastName, queryParameters.PostCode,
                    queryParameters.DateOfBirth, queryParameters.HackneyId)
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .AsNoTracking()
                .ToListAsync();

            var serviceUserCount = await _databaseContext.ServiceUsers
                .FilterServiceUser(queryParameters.FirstName, queryParameters.LastName, queryParameters.PostCode,
                    queryParameters.DateOfBirth, queryParameters.HackneyId)
                .CountAsync();

            return PagedList<ServiceUserDomain>.ToPagedList(serviceUsers.ToDomain(), serviceUserCount, queryParameters.PageNumber, queryParameters.PageSize);
        }
    }
}
