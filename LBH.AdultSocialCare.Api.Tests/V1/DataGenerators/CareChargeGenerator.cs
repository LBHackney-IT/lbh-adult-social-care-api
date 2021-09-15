using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.V1.AppConstants;
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

        public async Task<PackageCareCharge> GetCareCharge(int packageTypeId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync().ConfigureAwait(false);
            var supplier = await _context.Suppliers.FirstOrDefaultAsync().ConfigureAwait(false);
            var careCharge = _context.PackageCareCharges.Add(new PackageCareCharge
            {
                CreatorId = new Guid(UserConstants.DefaultApiUserId),
                UpdaterId = new Guid(UserConstants.DefaultApiUserId),
                PackageTypeId = packageTypeId,
                ServiceUserId = client.Id,
                SupplierId = supplier.Id
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return careCharge.Entity;
        }
    }
}
