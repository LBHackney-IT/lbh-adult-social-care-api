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
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CarePackageGateway : ICarePackageGateway
    {
        private readonly DatabaseContext _dbContext;

        public CarePackageGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarePackage> GetPackageAsync(Guid packageId, PackageFields fields = PackageFields.All)
        {
            var query = _dbContext.CarePackages.Where(p => p.Id == packageId);

            if (fields.HasFlag(PackageFields.Details)) query = query.Include(p => p.Details);
            if (fields.HasFlag(PackageFields.Reclaims)) query = query.Include(p => p.Reclaims);
            if (fields.HasFlag(PackageFields.Settings)) query = query.Include(p => p.Settings);
            if (fields.HasFlag(PackageFields.Supplier)) query = query.Include(p => p.Supplier);
            if (fields.HasFlag(PackageFields.Histories)) query = query.Include(p => p.Histories);
            if (fields.HasFlag(PackageFields.ServiceUser)) query = query.Include(p => p.ServiceUser);
            if (fields.HasFlag(PackageFields.PrimarySupportReason)) query = query.Include(p => p.PrimarySupportReason);

            return await query.FirstOrDefaultAsync();
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
