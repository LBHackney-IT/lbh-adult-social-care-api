using Amazon.DynamoDBv2.Model;
using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;
using BaseApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<DayCarePackageResponse> GetDayCarePackage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .AsNoTracking()
                .Select(dc => new DayCarePackageResponse
                {
                    DayCarePackageId = dc.DayCarePackageId,
                    PackageId = dc.PackageId,
                    ClientId = dc.ClientId,
                    IsFixedPeriodOrOngoing = dc.IsFixedPeriodOrOngoing,
                    StartDate = dc.StartDate,
                    EndDate = dc.EndDate,
                    IsThisAnImmediateService = dc.IsThisAnImmediateService,
                    IsThisUserUnderS117 = dc.IsThisUserUnderS117,
                    NeedToAddress = dc.NeedToAddress,
                    Monday = dc.Monday,
                    Tuesday = dc.Tuesday,
                    Wednesday = dc.Wednesday,
                    Thursday = dc.Thursday,
                    Friday = dc.Friday,
                    Saturday = dc.Saturday,
                    Sunday = dc.Sunday,
                    TransportNeeded = dc.TransportNeeded,
                    EscortNeeded = dc.EscortNeeded,
                    TermTimeConsiderationOptionId = dc.TermTimeConsiderationOptionId,
                    HowLong = dc.HowLong,
                    HowManyTimesPerMonth = dc.HowManyTimesPerMonth,
                    OpportunitiesNeedToAddress = dc.OpportunitiesNeedToAddress,
                    DateCreated = dc.DateCreated,
                    CreatorId = dc.CreatorId,
                    DateUpdated = dc.DateUpdated,
                    UpdaterId = dc.UpdaterId,
                    StatusId = dc.StatusId,
                    PackageName = dc.Package.PackageName,
                    ClientName = $"{dc.Client.FirstName} {dc.Client.MiddleName} {dc.Client.LastName}",
                    TermTimeConsiderationOptionName = dc.TermTimeConsiderationOption.OptionName,
                    CreatorName = $"{dc.Creator.FirstName} {dc.Creator.MiddleName} {dc.Creator.LastName}",
                    UpdaterName = $"{dc.Creator.FirstName} {dc.Creator.MiddleName} {dc.Creator.LastName}",
                    StatusName = dc.Status.StatusName
                }).SingleOrDefaultAsync().ConfigureAwait(false);

            if (dayCarePackage == null)
            {
                throw new ResourceNotFoundException($"Unable to locate day care package {dayCarePackageId.ToString()}");
            }

            return dayCarePackage;
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
