using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CarePackageGateway : ICarePackageGateway
    {
        private readonly DatabaseContext _dbContext;

        public CarePackageGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarePackage> GetPackageAsync(Guid packageId)
        {
            return await _dbContext.CarePackages
                .Where(p => p.Id == packageId)
                .Include(p => p.Details)
                .FirstOrDefaultAsync();
        }

        public async Task<CarePackage> GetPackagePlainAsync(Guid packageId, bool trackChanges = false)
        {
            return await _dbContext.CarePackages.Where(cp => cp.Id.Equals(packageId)).TrackChanges(trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CarePackageDomain>> GetAllPackagesAsync()
        {
            return await _dbContext.CarePackages.Select(cp => new CarePackageDomain
            {
                CarePackageId = cp.Id,
                PackageStatus = cp.Status.GetDisplayName(),
                ClientName = $"{cp.ServiceUser.FirstName} {cp.ServiceUser.MiddleName ?? string.Empty} {cp.ServiceUser.LastName}",
                ClientDateOfBirth = cp.ServiceUser.DateOfBirth,
                HackneyId = cp.ServiceUser.HackneyId,
                PostCode = cp.ServiceUser.PostCode,
                AssignedBrokerName = cp.Approver.Name,
                DateCreated = cp.DateCreated
            }).ToListAsync();
        }

        public void Create(CarePackage newCarePackage)
        {
            _dbContext.CarePackages.Add(newCarePackage);
        }
    }
}
