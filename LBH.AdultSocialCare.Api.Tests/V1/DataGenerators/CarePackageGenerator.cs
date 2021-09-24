using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;

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

            var package = new CarePackage
            {
                PackageType = type,
                Status = PackageStatus.New,
                ServiceUserId = serviceUser.Id
            };

            await _context.CarePackages.AddAsync(package).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return package;
        }
    }
}
