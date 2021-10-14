using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
                    DateCreated = cph.DateCreated,
                    Description = cph.Description,
                    RequestMoreInformation = cph.RequestMoreInformation,
                    //UserRole = cph.Creator.Role //TODO add role to user entity
                })
                .ToListAsync().ConfigureAwait(false);

            return carePackageHistory;
        }
    }
}
