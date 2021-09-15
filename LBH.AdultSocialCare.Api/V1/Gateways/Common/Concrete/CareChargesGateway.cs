using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CareChargesGateway : ICareChargesGateway
    {
        private readonly DatabaseContext _dbContext;

        public CareChargesGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProvisionalCareChargeAmountPlainDomain> GetUsingServiceUserIdAsync(Guid serviceUserId)
        {
            // Get client age
            var clientBirthDate = await _dbContext.Clients.Where(c => c.Id.Equals(serviceUserId)).Select(c => c.DateOfBirth)
                .SingleOrDefaultAsync().ConfigureAwait(false);
            if (clientBirthDate == null)
            {
                throw new ApiException($"Service user with Id {serviceUserId} not found");
            }

            var clientAge = clientBirthDate.GetAge(DateTime.Now);
            var todayDate = DateTimeOffset.Now.Date;

            // Use age to get provisional amount range
            var provisionalAmount = await _dbContext.ProvisionalCareChargeAmounts
                .Where(pca => (clientAge >= pca.AgeFrom && (pca.AgeTo == null || clientAge <= pca.AgeTo)) &&
                              (todayDate >= EF.Property<DateTime>(pca, nameof(pca.StartDate)).Date &&
                               (pca.EndDate == null || todayDate <= EF.Property<DateTime>(pca, nameof(pca.EndDate)).Date)))
                .OrderBy(pca => pca.StartDate)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return provisionalAmount?.ToDomain();
        }

        public async Task<bool> UpdateCareChargeElementStatusAsync(Guid packageCareChargeId, Guid careElementId, int newElementStatusId, DateTimeOffset? newEndDate)
        {
            // Get care charge element
            var element = await GetCareChargeElementAsync(packageCareChargeId, careElementId).ConfigureAwait(false);

            if (element == null)
            {
                throw new ApiException($"Care charge element with Id {careElementId} not found");
            }

            // Update element and save
            element.StatusId = newElementStatusId;

            if (newEndDate == null || newEndDate > element.StartDate)
            {
                element.EndDate = newEndDate;
            }

            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Failed to update care element status {ex.InnerException?.Message}",
                    ex);
            }
        }

        public async Task<CareChargeElementPlainDomain> CheckCareChargeElementExistsAsync(Guid packageCareChargeId,
            Guid careElementId)
        {
            var element = await _dbContext.CareChargeElements
                .Where(ce => ce.Id.Equals(careElementId) && ce.CareChargeId.Equals(packageCareChargeId))
                .AsNoTracking()
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (element == null)
            {
                throw new ApiException($"Care charge element with Id {careElementId} not found");
            }

            return element.ToPlainDomain();
        }

        private async Task<CareChargeElement> GetCareChargeElementAsync(Guid packageCareChargeId, Guid careElementId)
        {
            var element = await _dbContext.CareChargeElements
                .Where(ce => ce.Id.Equals(careElementId) && ce.CareChargeId.Equals(packageCareChargeId))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            return element;
        }

        public async Task<IEnumerable<CareChargeElementPlainDomain>> CreateCareChargeElementsAsync(IEnumerable<CareChargeElementPlainDomain> elementDomains)
        {
            var newElements = new List<CareChargeElement>();

            await using var transaction = await _dbContext.Database.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                foreach (var domain in elementDomains)
                {
                    var element = domain.ToEntity();
                    newElements.Add(element);

                    _dbContext.CareChargeElements.Add(element);
                }

                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                await transaction.CommitAsync().ConfigureAwait(false);

                return newElements.ToPlainDomain();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                throw new DbSaveFailedException("Saving care charge element failed", ex);
            }
        }

        public async Task<PagedList<CareChargePackagesDomain>> GetCareChargePackages(CareChargePackagesParameters parameters)
        {
            var careChargePackagesCount = await GetCareChargePackagesCount(parameters).ConfigureAwait(false);
            var careChargePackageList = await GetCareChargePackagesList(parameters).ConfigureAwait(false);

            var paginatedCareChargePackageList = careChargePackageList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return PagedList<CareChargePackagesDomain>.ToPagedList(paginatedCareChargePackageList, careChargePackagesCount, parameters.PageNumber, parameters.PageSize);
        }

        private async Task<int> GetCareChargePackagesCount(CareChargePackagesParameters parameters)
        {
            var packageCount = 0;

            packageCount += await _dbContext.ResidentialCarePackages
                .FilterCareChargeResidentialCareList(parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy).Include(p => p.ResidentialCareApprovalHistories)
                .Include(item => item.ResidentialCareBrokerageInfo)
                .Where(rc => rc.ResidentialCareBrokerageInfo.HasCareCharges == true)
                .CountAsync().ConfigureAwait(false);

            packageCount += await _dbContext.NursingCarePackages
                .FilterCareChargeNursingCareList(parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy).Include(p => p.NursingCareApprovalHistories)
                .Include(item => item.NursingCareBrokerageInfo)
                .Where(nc => nc.NursingCareBrokerageInfo.HasCareCharges == true)
                .CountAsync().ConfigureAwait(false);

            return packageCount;
        }

        private async Task<List<CareChargePackagesDomain>> GetCareChargePackagesList(CareChargePackagesParameters parameters)
        {
            var packageList = new List<CareChargePackagesDomain>();

            var residentialCare = await GetCareChargeResidentialCarePackages(parameters).ConfigureAwait(false);
            packageList.AddRange(residentialCare);

            var nursingCare = await GetCareChargeNursingCarePackages(parameters).ConfigureAwait(false);
            packageList.AddRange(nursingCare);

            return packageList;
        }

        private async Task<List<CareChargePackagesDomain>> GetCareChargeResidentialCarePackages(CareChargePackagesParameters parameters)
        {
            var residentialCarePackageList = await _dbContext.ResidentialCarePackages
                .FilterCareChargeResidentialCareList(parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy)
                .Include(item => item.ResidentialCareBrokerageInfo)
                .Include(item => item.Client)
                .Include(item => item.Updater)
                .Where(rc =>rc.ResidentialCareBrokerageInfo.HasCareCharges == true)
                .Select(rc => new CareChargePackagesDomain()
                {
                    ServiceUser = $"{rc.Client.FirstName} {rc.Client.LastName}",
                    DateOfBirth = rc.Client.DateOfBirth,
                    Address = $"{rc.Client.AddressLine1} {rc.Client.AddressLine2} {rc.Client.AddressLine3} {rc.Client.County} {rc.Client.Town} {rc.Client.PostCode}",
                    HackneyId = rc.Client.HackneyId,
                    PackageType = PackageTypesConstants.ResidentialCarePackage,
                    StartDate = rc.StartDate,
                    LastModified = rc.DateUpdated,
                    ModifiedBy = rc.Updater.Name
                })
                .ToListAsync().ConfigureAwait(false);
            return residentialCarePackageList;
        }

        private async Task<List<CareChargePackagesDomain>> GetCareChargeNursingCarePackages(CareChargePackagesParameters parameters)
        {
            var nursingCarePackageList = await _dbContext.NursingCarePackages
                .FilterCareChargeNursingCareList(parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy)
                .Include(item => item.NursingCareBrokerageInfo)
                .Include(item => item.Client)
                .Include(item => item.Updater)
                .Where(nc => nc.NursingCareBrokerageInfo.HasCareCharges == true)
                .Select(nc => new CareChargePackagesDomain()
                {
                    ServiceUser = $"{nc.Client.FirstName} {nc.Client.LastName}",
                    DateOfBirth = nc.Client.DateOfBirth,
                    Address = $"{nc.Client.AddressLine1} {nc.Client.AddressLine2} {nc.Client.AddressLine3} {nc.Client.County} {nc.Client.Town} {nc.Client.PostCode}",
                    HackneyId = nc.Client.HackneyId,
                    PackageType = PackageTypesConstants.NursingCarePackage,
                    PackageId = nc.Id,
                    StartDate = nc.StartDate,
                    LastModified = nc.DateUpdated,
                    ModifiedBy = nc.Updater.Name
                })
                .ToListAsync().ConfigureAwait(false);
            return nursingCarePackageList;
        }
    }
}
