using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Concrete
{
    public class CarePackageHistoryGateway : ICarePackageHistoryGateway
    {
        private readonly DatabaseContext _dbContext;

        public CarePackageHistoryGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CarePackageHistoryDomain>> ListAsync(Guid carePackageId)
        {
            var carePackageHistory = await _dbContext.CarePackageHistories
                .Where(cph => cph.CarePackageId.Equals(carePackageId))
                .Select(cph => new CarePackageHistoryDomain
                {
                    Id = cph.Id,
                    DateCreated = cph.DateCreated,
                    Description = cph.Status.GetDisplayName(),
                    RequestMoreInformation = cph.RequestMoreInformation,
                    CreatorName = cph.Creator.Name
                    //UserRole = cph.Creator.Role //TODO add role to user entity
                })
                .ToListAsync().ConfigureAwait(false);

            return carePackageHistory;
        }

        public async Task Create(CarePackageHistory newCarePackageHistory)
        {
            await _dbContext.CarePackageHistories.AddAsync(newCarePackageHistory);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Could not save care package history to database {ex.Message}");
            }
        }
    }
}
