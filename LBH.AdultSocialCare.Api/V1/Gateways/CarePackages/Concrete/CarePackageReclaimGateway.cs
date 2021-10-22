using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CarePackageReclaimDomain> CreateAsync(CarePackageReclaim carePackageReclaim)
        {
            var carePackage = await _dbContext.CarePackages
                .FirstOrDefaultAsync(item => item.Id == carePackageReclaim.CarePackageId);

            if (carePackage == null)
            {
                throw new EntityNotFoundException($"Unable to locate care package for {carePackageReclaim.CarePackageId}");
            }

            var entry = await _dbContext.CarePackageReclaims.AddAsync(carePackageReclaim);
            try
            {
                await _dbContext.SaveChangesAsync();
                return entry.Entity.ToDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException("Could not save care package reclaim to database" + ex.Message);
            }
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

        public async Task<CarePackageReclaim> GetAsync(Guid reclaimId)
        {
            return await _dbContext.CarePackageReclaims
                .FirstOrDefaultAsync(r => r.Id == reclaimId);
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
