using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Concrete
{
    public class CarePackageReclaimGateway : ICarePackageReclaimGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public CarePackageReclaimGateway(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CarePackageReclaim carePackageReclaim)
        {

            await _dbContext.CarePackageReclaims.AddAsync(carePackageReclaim);
        }

        public async Task<bool> UpdateAsync(CarePackageReclaimUpdateDomain carePackageReclaimUpdateDomain)
        {
            var carePackageReclaim = await _dbContext.CarePackageReclaims
                .FirstOrDefaultAsync(item => item.Id == carePackageReclaimUpdateDomain.Id);

            if (carePackageReclaim == null)
            {
                throw new EntityNotFoundException($"Unable to locate care package reclaim {carePackageReclaimUpdateDomain.Id}");
            }

            _mapper.Map(carePackageReclaimUpdateDomain, carePackageReclaim);
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Update for care package reclaim for {carePackageReclaimUpdateDomain.Id} failed {ex.Message}");
            }
        }

        public async Task<CarePackageReclaim> GetAsync(Guid reclaimId, bool trackChanges = false)
        {
            return await _dbContext.CarePackageReclaims
                .TrackChanges(trackChanges)
                .FirstOrDefaultAsync(r => r.Id == reclaimId);
        }

        public async Task<List<CarePackageReclaim>> GetListAsync(Guid packageId, ReclaimType? reclaimType, ReclaimSubType? reclaimSubType)
        {
            var carePackage = await _dbContext.CarePackages
                .FirstOrDefaultAsync(item => item.Id.Equals(packageId));

            if (carePackage is null)
            {
                throw new EntityNotFoundException($"Unable to locate care package {packageId}");
            }

            return await _dbContext.CarePackageReclaims
                .Where(reclaim =>
                    (reclaim.CarePackageId == packageId) &&
                    (reclaimType == null || reclaim.Type == reclaimType) &&
                    (reclaimSubType == null || reclaim.SubType == reclaimSubType))
                .ToListAsync();
        }

        public async Task<List<CarePackageReclaim>> GetListAsync(IEnumerable<Guid> reclaimIds)
        {
            return await _dbContext.CarePackageReclaims
                .Where(r => reclaimIds.Contains(r.Id))
                .ToListAsync();
        }

        public async Task<CarePackageReclaimDomain> GetSingleAsync(Guid carePackageId, ReclaimType reclaimType)
        {
            var carePackageReclaim = await _dbContext.CarePackageReclaims
                .Where(a => a.CarePackageId.Equals(carePackageId) &&
                            a.Type.Equals(reclaimType))
                .FirstOrDefaultAsync();

            return carePackageReclaim?.ToDomain();
        }

        public async Task<SinglePackageCareChargeDomain> GetSinglePackageCareCharge(Guid packageId)
        {
            var carePackage = await _dbContext.CarePackages
                .FirstOrDefaultAsync(item => item.Id.Equals(packageId));

            if (carePackage is null)
            {
                throw new EntityNotFoundException($"Unable to locate care package {packageId}");
            }

            return await _dbContext.CarePackages
                .Where(c => c.Id.Equals(packageId))
                .Include(item => item.ServiceUser)
                .Include(item => item.Supplier)
                .Include(item => item.Reclaims)
                .Include(item => item.Settings)
                .Select(c => new SinglePackageCareChargeDomain
                {
                    PackageType = c.PackageType.GetDisplayName(),
                    CareChargeStatus = c.Reclaims.Any(r => r.Type == ReclaimType.CareCharge) ? "Existing" : "New",
                    Supplier = c.Supplier.ToDomain(),
                    ServiceUser = c.ServiceUser.ToDomain(),
                    Settings = c.Settings.ToDomain(),
                    CareCharges = c.Reclaims.Where(r => r.Type == ReclaimType.CareCharge).ToDomain()
                }).SingleOrDefaultAsync();
        }
    }
}
