using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.Tests.V1.DataGenerators
{
    public class CarePackageGenerator
    {
        private readonly DatabaseContext _context;

        public CarePackageGenerator(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<CarePackage> CreatePackage(PackageType type)
        {
            var serviceUser = await _context.Clients.FirstOrDefaultAsync().ConfigureAwait(false);

            var package = TestDataHelper.CreateCarePackage(packageType: type, serviceUserId: serviceUser.Id, status: PackageStatus.New);

            await _context.CarePackages.AddAsync(package).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return package;
        }
    }
}
