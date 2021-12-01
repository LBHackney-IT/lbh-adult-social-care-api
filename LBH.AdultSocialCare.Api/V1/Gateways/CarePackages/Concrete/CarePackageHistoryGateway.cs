using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

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

        public void Create(CarePackageHistory newCarePackageHistory)
        {
            _dbContext.CarePackageHistories.Add(newCarePackageHistory);
        }
    }
}
