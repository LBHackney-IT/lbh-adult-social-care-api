using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways
{
    public class DayCarePackageGateway : IDayCarePackageGateway
    {
        private readonly DatabaseContext _dbContext;

        public DayCarePackageGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> CreateDayCarePackage(Infrastructure.Entities.DayCarePackage dayCarePackage)
        {
            var entry = await _dbContext.DayCarePackages.AddAsync(dayCarePackage).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return entry.Entity.DayCarePackageId;
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
