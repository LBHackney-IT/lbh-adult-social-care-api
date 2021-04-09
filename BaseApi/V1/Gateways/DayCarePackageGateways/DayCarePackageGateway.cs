using Amazon.DynamoDBv2.Model;
using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;
using BaseApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BaseApi.V1.Domain.DayCarePackageDomains;
using BaseApi.V1.Factories;

namespace BaseApi.V1.Gateways.DayCarePackageGateways
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

        public async Task<DayCarePackageDomain> GetDayCarePackage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .AsNoTracking()
                .Include(dc => dc.Package)
                .Include(dc => dc.Client)
                .Include(dc => dc.TermTimeConsiderationOption)
                .Include(dc => dc.Creator)
                .Include(dc => dc.Updater)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (dayCarePackage == null)
            {
                throw new ResourceNotFoundException($"Unable to locate day care package {dayCarePackageId.ToString()}");
            }

            return dayCarePackage.ToDomain();
        }
    }
}
