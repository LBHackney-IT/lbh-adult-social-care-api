using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
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

        public async Task<bool> UpdateAsync(CarePackageReclaimForUpdateDomain carePackageReclaimForUpdateDomain)
        {
            var carePackageReclaim = await _dbContext.CarePackageReclaims
                .FirstOrDefaultAsync(item => item.Id == carePackageReclaimForUpdateDomain.Id);

            if (carePackageReclaim == null)
            {
                throw new EntityNotFoundException($"Unable to locate care package reclaim {carePackageReclaimForUpdateDomain.Id}");
            }

            _mapper.Map(carePackageReclaimForUpdateDomain, carePackageReclaim);
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Update for care package reclaim for {carePackageReclaimForUpdateDomain.Id} failed {ex.Message}");
            }
        }

        public async Task<CarePackageReclaimDomain> GetAsync(Guid carePackageId, ReclaimType reclaimType)
        {
            var carePackageReclaim = await _dbContext.CarePackageReclaims
                .Where(a => a.CarePackageId.Equals(carePackageId) &&
                            a.Type.Equals(reclaimType))
                .FirstOrDefaultAsync();

            return carePackageReclaim?.ToDomain();
        }

        public async Task<PagedList<CareChargePackagesDomain>> GetCareChargePackages(CareChargePackagesParameters parameters)
        {
            var careChargePackagesCount = await GetCareChargePackagesCount(parameters);
            var careChargePackagesList = await GetCareChargePackagesList(parameters);

            var paginatedCareChargePackageList = careChargePackagesList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return PagedList<CareChargePackagesDomain>.ToPagedList(paginatedCareChargePackageList, careChargePackagesCount, parameters.PageNumber, parameters.PageSize);
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

        private async Task<int> GetCareChargePackagesCount(CareChargePackagesParameters parameters)
        {
            return await _dbContext.CarePackages
                .FilterCareChargeCarePackageList(parameters.Status, parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy)
                .CountAsync();
        }

        private async Task<List<CareChargePackagesDomain>> GetCareChargePackagesList(CareChargePackagesParameters parameters)
        {
            return await _dbContext.CarePackages
                .FilterCareChargeCarePackageList(parameters.Status, parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy)
                .Include(item => item.ServiceUser)
                .Include(item => item.Updater)
                .Include(item => item.Reclaims)
                .Select(c => new CareChargePackagesDomain()
                {
                    Status = c.Reclaims.Any(r => r.Type == ReclaimType.CareCharge) ? "Existing" : "New",
                    ServiceUser = $"{c.ServiceUser.FirstName} {c.ServiceUser.LastName}",
                    DateOfBirth = c.ServiceUser.DateOfBirth,
                    Address = $"{c.ServiceUser.AddressLine1} {c.ServiceUser.AddressLine2} {c.ServiceUser.AddressLine3} {c.ServiceUser.County} {c.ServiceUser.Town} {c.ServiceUser.PostCode}",
                    HackneyId = c.ServiceUser.HackneyId,
                    PackageType = c.PackageType.GetDisplayName(),
                    PackageId = c.Id,
                    StartDate = c.DateCreated,
                    LastModified = c.DateUpdated,
                    ModifiedBy = c.Updater.Name
                })
                .ToListAsync();
        }
    }
}
