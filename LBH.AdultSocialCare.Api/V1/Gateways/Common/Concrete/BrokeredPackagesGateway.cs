using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class BrokeredPackagesGateway : IBrokeredPackagesGateway
    {
        private readonly DatabaseContext _databaseContext;

        public BrokeredPackagesGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<PagedList<BrokeredPackagesDomain>> GetBrokeredPackages(BrokeredPackagesParameters parameters, int statusId)
        {
            var brokeredPackagesCount = await GetPackagesCount(parameters, statusId).ConfigureAwait(false);
            var packageList = await GetPackagesList(parameters, statusId).ConfigureAwait(false);

            var paginatedPackageList = packageList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return PagedList<BrokeredPackagesDomain>.ToPagedList(paginatedPackageList, brokeredPackagesCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<bool> AssignToUser(Guid packageId, Guid userId)
        {
            var nursingCarePackageCount = await _databaseContext.NursingCarePackages
                .Where(item => item.Id == packageId)
                .CountAsync().ConfigureAwait(false);

            if (nursingCarePackageCount > 0)
            {
                var nursingPackage = await _databaseContext.NursingCarePackages
                    .FirstOrDefaultAsync(item => item.Id == packageId)
                    .ConfigureAwait(false);
                nursingPackage.AssignedUserId = userId;
            }

            var residentialCarePackageCount = await _databaseContext.ResidentialCarePackages
                .Where(item => item.Id == packageId)
                .CountAsync().ConfigureAwait(false);

            if (residentialCarePackageCount > 0)
            {
                var residentialCarePackage = await _databaseContext.ResidentialCarePackages
                    .FirstOrDefaultAsync(item => item.Id == packageId)
                    .ConfigureAwait(false);
                residentialCarePackage.AssignedUserId = userId;
            }

            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Assign user to package failed");
            }
        }

        private async Task<List<BrokeredPackagesDomain>> GetPackagesList(BrokeredPackagesParameters parameters, int statusId)
        {
            var packageList = new List<BrokeredPackagesDomain>();

            //var homeCare = await GetHomeCarePackages(parameters, statusId).ConfigureAwait(false);
            //packageList.AddRange(homeCare);

            if (!parameters.PackageTypeId.HasValue || parameters.PackageTypeId == PackageTypesConstants.ResidentialCarePackageId)
            {
                var residentialCare = await GetResidentialCarePackages(parameters, statusId).ConfigureAwait(false);
                packageList.AddRange(residentialCare);
            }

            if (!parameters.PackageTypeId.HasValue || parameters.PackageTypeId == PackageTypesConstants.NursingCarePackageId)
            {
                var nursingCare = await GetNursingPackages(parameters, statusId).ConfigureAwait(false);
                packageList.AddRange(nursingCare);
            }

            return packageList;
        }

        private async Task<List<BrokeredPackagesDomain>> GetResidentialCarePackages(BrokeredPackagesParameters parameters, int statusId)
        {
            var residentialCarePackageList = await _databaseContext.ResidentialCarePackages
                .FilterBrokeredResidentialCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId, parameters.StageId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.Stage)
                .Include(item => item.ResidentialCareApprovalHistories)
                .Select(rc => new BrokeredPackagesDomain()
                {
                    PackageId = rc.Id,
                    ServiceUserId = (Guid) rc.ClientId,
                    ServiceUser = $"{rc.Client.FirstName} {rc.Client.MiddleName} {rc.Client.LastName}",
                    HackneyId = rc.Client.HackneyId,
                    PackageType = PackageTypesConstants.ResidentialCarePackage,
                    PackageTypeId = PackageTypesConstants.ResidentialCarePackageId,
                    OwnerId = rc.ResidentialCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageBrokeredId)
                        .Select(x => x.CreatorId).SingleOrDefault(),
                    Owner = _databaseContext.Users
                        .Where(x => x.Id == rc.AssignedUserId)
                        .Select(x => x.Name).SingleOrDefault(),
                    StartDate = rc.StartDate,
                    Stage = rc.Stage.StageName,
                    DaysSinceApproval = rc.ResidentialCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                        .Select(x => DateTimeOffset.Now.Date.Subtract(x.DateCreated.Date).Days).SingleOrDefault(),
                    LastUpdated = rc.DateUpdated
                })
                .ToListAsync().ConfigureAwait(false);
            return residentialCarePackageList;
        }

        private async Task<List<BrokeredPackagesDomain>> GetHomeCarePackages(BrokeredPackagesParameters parameters, int? statusId)
        {
            var homeCarePackageList = await _databaseContext.HomeCarePackage
                .FilterBrokeredHomeCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId, parameters.StageId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.Stage)
                .Include(item => item.HomeCareApprovalHistories)
                .Select(hc => new BrokeredPackagesDomain()
                {
                    PackageId = hc.Id,
                    ServiceUserId = hc.ClientId,
                    ServiceUser = $"{hc.Client.FirstName} {hc.Client.MiddleName} {hc.Client.LastName}",
                    HackneyId = hc.Client.HackneyId,
                    PackageType = PackageTypesConstants.HomeCarePackage,
                    PackageTypeId = PackageTypesConstants.HomeCarePackageId,
                    OwnerId = hc.HomeCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageBrokeredId)
                        .Select(x => x.UserId).SingleOrDefault(),
                    Owner = hc.HomeCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageBrokeredId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    StartDate = hc.StartDate,
                    Stage = hc.Stage.StageName,
                    DaysSinceApproval = hc.HomeCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                        .Select(x => DateTimeOffset.Now.Date.Subtract(x.ApprovedDate.Date).Days).SingleOrDefault(),
                    LastUpdated = hc.DateUpdated
                })
                .ToListAsync().ConfigureAwait(false);
            return homeCarePackageList;
        }

        private async Task<List<BrokeredPackagesDomain>> GetNursingPackages(BrokeredPackagesParameters parameters, int statusId)
        {
            var nursingCarePackageList = await _databaseContext.NursingCarePackages
                .FilterBrokeredNursingCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId, parameters.StageId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.Stage)
                .Include(item => item.NursingCareApprovalHistories)
                .Select(nc => new BrokeredPackagesDomain()
                {
                    PackageId = nc.Id,
                    ServiceUserId = (Guid) nc.ClientId,
                    ServiceUser = $"{nc.Client.FirstName} {nc.Client.MiddleName} {nc.Client.LastName}",
                    HackneyId = nc.Client.HackneyId,
                    PackageType = PackageTypesConstants.NursingCarePackage,
                    PackageTypeId = PackageTypesConstants.NursingCarePackageId,
                    OwnerId = nc.NursingCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageBrokeredId)
                        .Select(x => x.CreatorId).SingleOrDefault(),
                    Owner = _databaseContext.Users
                            .Where(x => x.Id == nc.AssignedUserId)
                            .Select(x => x.Name).SingleOrDefault(),
                    StartDate = nc.StartDate,
                    Stage = nc.Stage.StageName,
                    DaysSinceApproval = nc.NursingCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                        .Select(x => DateTimeOffset.Now.Date.Subtract(x.DateCreated.Date).Days).SingleOrDefault(),
                    LastUpdated = nc.DateUpdated
                })
                .ToListAsync().ConfigureAwait(false);
            return nursingCarePackageList;
        }

        private async Task<int> GetPackagesCount(BrokeredPackagesParameters parameters, int statusId)
        {
            var packageCount = 0;

            if (!parameters.PackageTypeId.HasValue || parameters.PackageTypeId == PackageTypesConstants.ResidentialCarePackageId)
            {
                packageCount += await _databaseContext.ResidentialCarePackages
                    .FilterBrokeredResidentialCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId, parameters.StageId)
                    .CountAsync().ConfigureAwait(false);
            }

            if (!parameters.PackageTypeId.HasValue || parameters.PackageTypeId == PackageTypesConstants.NursingCarePackageId)
            {
                packageCount += await _databaseContext.NursingCarePackages
                    .FilterBrokeredNursingCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId, parameters.StageId)
                    .CountAsync().ConfigureAwait(false);
            }

            //packageCount += await _databaseContext.HomeCarePackage
            //    .FilterBrokeredHomeCareList(statusId, parameters.HackneyId, parameters.ClientId, parameters.SocialWorkerId, parameters.StageId)
            //    .CountAsync().ConfigureAwait(false);

            return packageCount;
        }
    }
}
