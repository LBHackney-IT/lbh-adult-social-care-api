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
            // TODO: VK: optimize
            return await _dbContext.CarePackages
                .Where(p => p.Id == packageId)
                .Include(p => p.Details)
                .Include(p => p.Reclaims)
                .Include(p => p.Settings)
                .Include(p => p.PrimarySupportReason)
                .Include(p => p.ServiceUser)
                .Include(p => p.Supplier)
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

        public async Task<CarePackageSettingsDomain> GetCarePackageSettingsAsync(Guid carePackageId)
        {
            return await _dbContext.CarePackageSettings.Where(ps => ps.CarePackageId.Equals(carePackageId))
                .Select(ps => new CarePackageSettingsDomain
                {
                    Id = ps.Id,
                    CarePackageId = ps.CarePackageId,
                    PackageType = ps.Package.PackageType,
                    PrimarySupportReasonId = ps.Package.PrimarySupportReasonId,
                    PrimarySupportReasonName = ps.Package.PrimarySupportReason.PrimarySupportReasonName,
                    HasRespiteCare = ps.HasRespiteCare,
                    HasDischargePackage = ps.HasDischargePackage,
                    IsImmediate = ps.IsImmediate,
                    IsReEnablement = ps.IsReEnablement,
                    IsS117Client = ps.IsS117Client
                }).SingleOrDefaultAsync();
        }

        public void Create(CarePackage newCarePackage)
        {
            _dbContext.CarePackages.Add(newCarePackage);
        }
    }
}
