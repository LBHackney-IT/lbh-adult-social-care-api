using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Concrete
{
    // ReSharper disable once UnusedType.Global
    public class CarePackageGateway : BaseGateway, ICarePackageGateway
    {
        public CarePackageGateway(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Guid>> GetUnpaidPackageIdsAsync(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return await DbContext.CarePackages
                .AsNoTracking()
                .Where(package =>
                    package.Details.Any(detail =>
                        DbContext.CompareDates(detail.StartDate, /* < */ endDate) == -1 &&
                        (detail.EndDate == null || DbContext.CompareDates(detail.EndDate, /* >= */ startDate.Date) >= 0)) ||
                    package.Reclaims.Any(reclaim =>
                        DbContext.CompareDates(reclaim.StartDate, /* < */ endDate) == -1 &&
                        (reclaim.EndDate == null || DbContext.CompareDates(reclaim.EndDate, /* >= */ startDate.Date) >= 0)))
                .Select(package => package.Id)
                .ToListAsync();
        }

        public async Task<IList<CarePackage>> GetListAsync(IList<Guid> ids)
        {
            return await DbContext.CarePackages
                .Include(package => package.Details)
                .Include(package => package.Reclaims)
                .AsNoTracking()
                .Where(package => ids.Contains(package.Id))
                .ToListAsync();
        }
    }
}
