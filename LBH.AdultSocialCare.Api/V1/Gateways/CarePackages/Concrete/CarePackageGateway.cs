using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Concrete
{
    public class CarePackageGateway : ICarePackageGateway
    {
        private readonly DatabaseContext _dbContext;

        public CarePackageGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BrokerPackageViewDomain> GetBrokerPackageViewListAsync(
            BrokerPackageViewQueryParameters queryParameters)
        {
            var packages = await _dbContext.CarePackages
                .FilterBrokerViewPackages(queryParameters.ServiceUserId, queryParameters.ServiceUserName,
                    queryParameters.Status, queryParameters.BrokerId, queryParameters.FromDate, queryParameters.ToDate)
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .AsNoTracking()
                .Select(cp => new BrokerPackageItemDomain
                {
                    PackageId = cp.Id,
                    ServiceUserId = cp.ServiceUserId,
                    ServiceUserName =
                        $"{cp.ServiceUser.FirstName} {cp.ServiceUser.MiddleName ?? string.Empty} {cp.ServiceUser.LastName}",
                    DateOfBirth = cp.ServiceUser.DateOfBirth,
                    Address = cp.ServiceUser.AddressLine1,
                    HackneyId = cp.ServiceUser.HackneyId.ToString(),
                    PackageType = cp.PackageType.GetDisplayName(),
                    PackageStatus = cp.Status.GetDisplayName(),
                    BrokerName = cp.Broker.Name,
                    DateAssigned = cp.DateCreated
                }).ToListAsync();

            var packageCount = await _dbContext.CarePackages
                .FilterBrokerViewPackages(queryParameters.ServiceUserId, queryParameters.ServiceUserName,
                    queryParameters.Status, queryParameters.BrokerId, queryParameters.FromDate, queryParameters.ToDate)
                .CountAsync();

            var pagedPackages = PagedList<BrokerPackageItemDomain>.ToPagedList(packages, packageCount, queryParameters.PageNumber, queryParameters.PageSize);

            var statusCount = await _dbContext.CarePackages
                .FilterBrokerViewPackages(queryParameters.ServiceUserId, queryParameters.ServiceUserName,
                    queryParameters.Status, queryParameters.BrokerId, queryParameters.FromDate, queryParameters.ToDate)
                .Select(p => new { p.Id, p.Status })
                .GroupBy(p => p.Status)
                .Select(p => new CarePackageByStatusDomain
                {
                    StatusName = p.Key.GetDisplayName(),
                    Number = p.Count()
                })
                .ToListAsync();

            return new BrokerPackageViewDomain
            {
                Packages = pagedPackages,
                StatusCount = statusCount.ToDictionary(statusGroup => statusGroup.StatusName, statusGroup => statusGroup.Number),
                PagingMetaData = pagedPackages.PagingMetaData
            };
        }

        public async Task<CarePackage> GetPackageAsync(Guid packageId, PackageFields fields = PackageFields.None, bool trackChanges = false)
        {
            var query = BuildPackageQuery(
                    _dbContext.CarePackages.Where(p => p.Id == packageId), fields)
                .TrackChanges(trackChanges);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<CarePackage> GetPackagePlainAsync(Guid packageId, bool trackChanges = false)
        {
            return await _dbContext.CarePackages.Where(cp => cp.Id.Equals(packageId)).TrackChanges(trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CarePackageListItemDomain>> GetAllPackagesAsync()
        {
            return await _dbContext.CarePackages.Select(cp => new CarePackageListItemDomain
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

        public async Task DeleteReclaimsForPackage(Guid packageId, ReclaimType reclaimType)
        {
            var reclaims = await _dbContext.CarePackageReclaims
                .Where(pr => pr.CarePackageId.Equals(packageId) && pr.Type.Equals(reclaimType)).ToListAsync();
            _dbContext.CarePackageReclaims.RemoveRange(reclaims);
        }

        public async Task<List<Guid>> GetUnpaidPackageIdsAsync(DateTimeOffset dateTo)
        {
            // TODO: VK: Temporary stub, handle PaidUpTo dates
            return await _dbContext.CarePackages
                .Select(p => p.Id)
                .ToListAsync();
        }

        public async Task<List<CarePackage>> GetByIdsAsync(IEnumerable<Guid> packageIds, PackageFields fields = PackageFields.All)
        {
            var query = BuildPackageQuery(
                _dbContext.CarePackages.Where(p => packageIds.Contains(p.Id)), fields);

            return await query.ToListAsync();
        }

        public async Task<List<CarePackage>> GetServiceUserPackagesAsync(Guid serviceUserId, PackageFields fields = PackageFields.None,
            bool trackChanges = false)
        {
            var query = BuildPackageQuery(_dbContext.CarePackages.Where(p => p.ServiceUserId.Equals(serviceUserId)),
                fields);

            return await query.ToListAsync();
        }

        public async Task<int> GetServiceUserActivePackagesCount(Guid serviceUserId, PackageType packageType)
        {
            return await _dbContext.CarePackages
                .Where(p => p.ServiceUserId == serviceUserId &&
                            p.PackageType == packageType &&
                            p.Status != PackageStatus.Cancelled &&
                            p.Status != PackageStatus.Ended)
                .CountAsync();
        }

        private static IQueryable<CarePackage> BuildPackageQuery(IQueryable<CarePackage> query, PackageFields fields)
        {
            if (fields.HasFlag(PackageFields.Details)) query = query.Include(p => p.Details);
            if (fields.HasFlag(PackageFields.Reclaims)) query = query.Include(p => p.Reclaims);
            if (fields.HasFlag(PackageFields.Settings)) query = query.Include(p => p.Settings);
            if (fields.HasFlag(PackageFields.Supplier)) query = query.Include(p => p.Supplier);
            if (fields.HasFlag(PackageFields.Histories)) query = query.Include(p => p.Histories);
            if (fields.HasFlag(PackageFields.ServiceUser)) query = query.Include(p => p.ServiceUser);
            if (fields.HasFlag(PackageFields.PrimarySupportReason)) query = query.Include(p => p.PrimarySupportReason);
            if (fields.HasFlag(PackageFields.Broker)) query = query.Include(p => p.Broker);
            if (fields.HasFlag(PackageFields.Approver)) query = query.Include(p => p.Approver);

            return query;
        }
    }
}
