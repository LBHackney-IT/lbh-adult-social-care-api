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
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;

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
            var clientBirthDate = await _dbContext.ServiceUsers
                .Where(c => c.Id.Equals(serviceUserId))
                .Select(c => c.DateOfBirth)
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

        public async Task<PagedList<CareChargePackagesDomain>> GetCareChargePackages(CareChargePackagesParameters parameters)
        {
            var careChargePackagesCount = await GetCareChargePackagesCount(parameters);
            var careChargePackagesList = await GetCareChargePackagesList(parameters);

            var paginatedCareChargePackageList = careChargePackagesList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return PagedList<CareChargePackagesDomain>.ToPagedList(paginatedCareChargePackageList, careChargePackagesCount, parameters.PageNumber, parameters.PageSize);
        }

        private async Task<int> GetCareChargePackagesCount(CareChargePackagesParameters parameters)
        {
            return await _dbContext.CarePackages
                .FilterCareChargeCarePackageList(parameters.Status, parameters.ModifiedBy, parameters.OrderByDate, parameters.IsS117ClientConfirmed)
                .CountAsync();
        }

        private async Task<List<CareChargePackagesDomain>> GetCareChargePackagesList(CareChargePackagesParameters parameters)
        {
            return await _dbContext.CarePackages
                .FilterCareChargeCarePackageList(parameters.Status, parameters.ModifiedBy, parameters.OrderByDate, parameters.IsS117ClientConfirmed)
                .Include(item => item.Settings)
                .Include(item => item.ServiceUser)
                .Include(item => item.Updater)
                .Include(item => item.Reclaims)
                .Select(c => new CareChargePackagesDomain
                {
                    Status = c.Reclaims.Any(r => r.Type == ReclaimType.CareCharge && r.SubType != ReclaimSubType.CareChargeProvisional && c.Settings.IsS117Client && c.Settings.IsS117ClientConfirmed == false) ? "S117" : c.Reclaims.Any(r => r.Type == ReclaimType.CareCharge && r.SubType != ReclaimSubType.CareChargeProvisional) ? "Existing" : "New",
                    ServiceUser = $"{c.ServiceUser.FirstName} {c.ServiceUser.LastName}",
                    DateOfBirth = c.ServiceUser.DateOfBirth,
                    Address = $"{c.ServiceUser.AddressLine1} {c.ServiceUser.AddressLine2} {c.ServiceUser.AddressLine3} {c.ServiceUser.County} {c.ServiceUser.Town} {c.ServiceUser.PostCode}",
                    HackneyId = c.ServiceUser.HackneyId,
                    PackageType = c.PackageType.GetDisplayName(),
                    PackageId = c.Id,
                    IsS117Client = c.Settings.IsS117Client,
                    StartDate = c.DateCreated,
                    LastModified = c.DateUpdated,
                    ModifiedBy = c.Updater.Name
                })
                .ToListAsync();
        }
    }
}
