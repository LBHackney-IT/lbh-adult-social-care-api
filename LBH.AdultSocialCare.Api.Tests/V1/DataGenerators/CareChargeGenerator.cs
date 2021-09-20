using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.Tests.V1.DataGenerators
{
    public class CareChargeGenerator
    {
        private readonly DatabaseContext _context;

        public CareChargeGenerator(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<PackageCareCharge> GetCareCharge(int packageTypeId, Guid packageId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync().ConfigureAwait(false);
            var supplier = await _context.Suppliers.FirstOrDefaultAsync().ConfigureAwait(false);
            var careCharge = _context.PackageCareCharges.Add(new PackageCareCharge
            {
                PackageId = packageId,
                CreatorId = new Guid(UserConstants.DefaultApiUserId),
                UpdaterId = new Guid(UserConstants.DefaultApiUserId),
                PackageTypeId = packageTypeId,
                ServiceUserId = client.Id,
                SupplierId = supplier.Id
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return careCharge.Entity;
        }

        public async Task<IEnumerable<CareChargeElement>> GetElements(Guid careChargeId, int count)
        {
            var result = new List<CareChargeElement>();

            for (var i = 0; i < count; i++)
            {
                result.Add(_context.CareChargeElements.Add(new CareChargeElement
                {
                    CareChargeId = careChargeId,
                    Amount = 10.0m,
                    ClaimCollectorId = PackageCostClaimersConstants.Hackney,
                    StatusId = (int) ReclaimStatus.Active,
                    TypeId = (int) CareChargeElementTypeEnum.WithoutPropertyOneToTwelveWeeks
                }).Entity);
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }
    }
}
