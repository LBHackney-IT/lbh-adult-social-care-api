using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ApprovedPackagesGateways
{
    public class ApprovedPackagesGateway : IApprovedPackagesGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ApprovedPackagesGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<PagedList<ApprovedPackagesDomain>> GetApprovedPackages(ApprovedPackagesParameters parameters, int statusId)
        {
            var approvedPackagesCount = await GetPackagesCount(parameters, statusId).ConfigureAwait(false);
            var packageList = await GetPackagesList(parameters, statusId).ConfigureAwait(false);

            var paginatedPackageList = packageList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return PagedList<ApprovedPackagesDomain>.ToPagedList(paginatedPackageList, approvedPackagesCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<IEnumerable<UsersMinimalDomain>> GetUsers(int roleId)
        {
            var res = await _databaseContext.Users
                .Select(x => new UsersMinimalDomain()
                {
                    Id = x.Id,
                    UserName = x.Name
                }
                )
                .ToListAsync().ConfigureAwait(false);
            return res;
        }

        private async Task<List<ApprovedPackagesDomain>> GetPackagesList(ApprovedPackagesParameters parameters, int statusId)
        {
            var packageList = new List<ApprovedPackagesDomain>();

            //var homeCare = await GetHomeCarePackages(parameters, statusId).ConfigureAwait(false);
            //packageList.AddRange(homeCare);

            var residentialCare = await GetResidentialCarePackages(parameters, statusId).ConfigureAwait(false);
            packageList.AddRange(residentialCare);

            var nursingCare = await GetNursingPackages(parameters, statusId).ConfigureAwait(false);
            packageList.AddRange(nursingCare);

            //var dayCare = await GetDayCarePackages(parameters, statusId).ConfigureAwait(false);
            //packageList.AddRange(dayCare);

            return packageList;
        }

        private async Task<List<ApprovedPackagesDomain>> GetResidentialCarePackages(ApprovedPackagesParameters parameters, int statusId)
        {
            var residentialCarePackageList = await _databaseContext.ResidentialCarePackages
                .FilterApprovedResidentialCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.ResidentialCareApprovalHistories)
                .Select(rc => new ApprovedPackagesDomain()
                {
                    PackageId = rc.Id,
                    ServiceUserId = (Guid) rc.ClientId,
                    ServiceUser = $"{rc.Client.FirstName} {rc.Client.MiddleName} {rc.Client.LastName}",
                    HackneyId = rc.Client.HackneyId,
                    PackageType = PackageTypesConstants.ResidentialCarePackage,
                    PackageTypeId = PackageTypesConstants.ResidentialCarePackageId,
                    Approver = rc.ResidentialCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageApprovedId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    SubmittedBy = rc.ResidentialCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    LastUpdated = rc.DateUpdated,
                    CareValue = _databaseContext.ResidentialCareBrokerageInfos
                            .Where(x => x.ResidentialCarePackageId == rc.Id)
                            .Select(x => x.ResidentialCore + x.AdditionalNeedsPayment + x.AdditionalNeedsPaymentOneOff).SingleOrDefault(),
                })
                .ToListAsync().ConfigureAwait(false);
            return residentialCarePackageList;
        }

        private async Task<List<ApprovedPackagesDomain>> GetHomeCarePackages(ApprovedPackagesParameters parameters, int statusId)
        {
            var homeCarePackageList = await _databaseContext.HomeCarePackage
                .FilterApprovedHomeCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.HomeCareApprovalHistories)
                .Select(hc => new ApprovedPackagesDomain()
                {
                    PackageId = hc.Id,
                    ServiceUserId = hc.ClientId,
                    ServiceUser = $"{hc.Client.FirstName} {hc.Client.MiddleName} {hc.Client.LastName}",
                    HackneyId = hc.Client.HackneyId,
                    PackageType = PackageTypesConstants.HomeCarePackage,
                    PackageTypeId = PackageTypesConstants.HomeCarePackageId,
                    Approver = hc.HomeCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageApprovedId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    SubmittedBy = hc.HomeCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    LastUpdated = hc.DateUpdated,
                    CareValue = _databaseContext.HomeCarePackageCosts
                        .Where(x => x.HomeCarePackageId == hc.Id)
                        .Sum(x => x.TotalCost),
                })
                .ToListAsync().ConfigureAwait(false);
            return homeCarePackageList;
        }

        private async Task<List<ApprovedPackagesDomain>> GetNursingPackages(ApprovedPackagesParameters parameters, int statusId)
        {
            var nursingCarePackageList = await _databaseContext.NursingCarePackages
                .FilterApprovedNursingCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.NursingCareApprovalHistories)
                .Select(nc => new ApprovedPackagesDomain()
                {
                    PackageId = nc.Id,
                    ServiceUserId = (Guid) nc.ClientId,
                    ServiceUser = $"{nc.Client.FirstName} {nc.Client.MiddleName} {nc.Client.LastName}",
                    HackneyId = nc.Client.HackneyId,
                    PackageType = PackageTypesConstants.NursingCarePackage,
                    PackageTypeId = PackageTypesConstants.NursingCarePackageId,
                    Approver = nc.NursingCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageApprovedId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    SubmittedBy = nc.NursingCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    LastUpdated = nc.DateUpdated,
                    CareValue = _databaseContext.NursingCareBrokerageInfos
                        .Where(x => x.NursingCarePackageId == nc.Id)
                        .Sum(x => x.NursingCore + x.AdditionalNeedsPayment + x.AdditionalNeedsPaymentOneOff),
                })
                .ToListAsync().ConfigureAwait(false);
            return nursingCarePackageList;
        }

        private async Task<List<ApprovedPackagesDomain>> GetDayCarePackages(ApprovedPackagesParameters parameters, int statusId)
        {
            var dayCarePackageList = await _databaseContext.DayCarePackages
                .FilterApprovedDayCareList(statusId, parameters.HackneyId, parameters.SocialWorkerId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.DayCareApprovalHistories)
                .Select(dc => new ApprovedPackagesDomain()
                {
                    PackageId = dc.DayCarePackageId,
                    ServiceUserId = dc.ClientId,
                    ServiceUser = $"{dc.Client.FirstName} {dc.Client.MiddleName} {dc.Client.LastName}",
                    HackneyId = dc.Client.HackneyId,
                    PackageType = PackageTypesConstants.DayCarePackage,
                    PackageTypeId = PackageTypesConstants.DayCarePackageId,
                    Approver = dc.DayCareApprovalHistories
                        .Where(x => x.PackageStatusId == ApprovalHistoryConstants.PackageApprovedId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    SubmittedBy = dc.DayCareApprovalHistories
                        .Where(x => x.PackageStatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                        .Select(x => x.Creator.Name).SingleOrDefault(),
                    LastUpdated = dc.DateUpdated,
                    CareValue = _databaseContext.DayCareBrokerageInfo
                        .Where(x => x.DayCarePackageId == dc.DayCarePackageId)
                        .Select(x => x.CorePackageCostPerDay).SingleOrDefault(),
                })
                .ToListAsync().ConfigureAwait(false);
            return dayCarePackageList;
        }

        private async Task<int> GetPackagesCount(ApprovedPackagesParameters parameters, int statusId)
        {
            var packageCount = 0;
            packageCount += await _databaseContext.ResidentialCarePackages
                .FilterApprovedResidentialCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
                .CountAsync().ConfigureAwait(false);

            packageCount += await _databaseContext.NursingCarePackages
                .FilterApprovedNursingCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
                .CountAsync().ConfigureAwait(false);

            //packageCount += await _databaseContext.DayCarePackages
            //    .FilterApprovedDayCareList(statusId, parameters.HackneyId, parameters.SocialWorkerId)
            //    .CountAsync().ConfigureAwait(false);

            //packageCount += await _databaseContext.HomeCarePackage
            //    .FilterApprovedHomeCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
            //    .CountAsync().ConfigureAwait(false);

            return packageCount;
        }
    }
}
