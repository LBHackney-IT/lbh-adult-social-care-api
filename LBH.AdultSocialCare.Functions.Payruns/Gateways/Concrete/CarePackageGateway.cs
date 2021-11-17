using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.CarePackages;
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
                .Where(p => p.Status == PackageStatus.Approved &&
                            !DbContext.Invoices.Any(i => i.PackageId == p.Id))
                .AsNoTracking()
                .Select(p => p.Id)
                .ToListAsync();
        }

        public async Task<IList<CarePackage>> GetListAsync(IList<Guid> ids)
        {
            return await DbContext.CarePackages
                .Where(p => ids.Contains(p.Id))
                .AsNoTracking()
                .Include(p => p.Details)
                .Include(p => p.Reclaims)
                .ToListAsync();
        }

        public async Task<int> GetInvoicesCountAsync()
        {
            return await DbContext.Invoices.CountAsync();
        }
    }
}
