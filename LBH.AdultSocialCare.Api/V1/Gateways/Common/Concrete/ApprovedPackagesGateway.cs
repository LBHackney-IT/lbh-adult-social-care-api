using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
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

        public async Task<IEnumerable<UsersMinimalDomain>> GetUsers(Guid roleId)
        {
            var result = await _databaseContext.Roles
                .Join(_databaseContext.UserRoles,
                    role => role.Id,
                    userRole => userRole.RoleId,
                    (role, userRole) => new { RoleId = role.Id, userRole.UserId })
                .Join(_databaseContext.Users,
                    userRole => userRole.UserId,
                    user => user.Id,
                    (userRole, user) => new { userRole.RoleId, user.Name, user.Id })
                .Where(userInfo => userInfo.RoleId == roleId)
                .Select(userInfo => new UsersMinimalDomain { Id = userInfo.Id, UserName = userInfo.Name })
                .ToListAsync().ConfigureAwait(false);

            return result;
        }

        private async Task<List<ApprovedPackagesDomain>> GetPackagesList(ApprovedPackagesParameters parameters, int statusId)
        {
            var packageList = new List<ApprovedPackagesDomain>();

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

            //var homeCare = await GetHomeCarePackages(parameters, statusId).ConfigureAwait(false);
            //packageList.AddRange(homeCare);

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
                .Where(p => !parameters.ApproverId.HasValue ||
                            p.ResidentialCareApprovalHistories.Any(h => h.Creator.Id == parameters.ApproverId))
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
                            .Sum(x => x.ResidentialCore + x.ResidentialCareAdditionalNeedsCosts.Sum(anc => anc.AdditionalNeedsCost)),
                })
                .ToListAsync().ConfigureAwait(false);
            return residentialCarePackageList;
        }

        private async Task<List<ApprovedPackagesDomain>> GetNursingPackages(ApprovedPackagesParameters parameters, int statusId)
        {
            var nursingCarePackageList = await _databaseContext.NursingCarePackages
                .FilterApprovedNursingCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.NursingCareApprovalHistories)
                .Where(p => !parameters.ApproverId.HasValue ||
                            p.NursingCareApprovalHistories.Any(h => h.Creator.Id == parameters.ApproverId))
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
                        .Sum(x => x.NursingCore + x.NursingCareAdditionalNeedsCosts.Sum(anc => anc.AdditionalNeedsCost)),
                })
                .ToListAsync().ConfigureAwait(false);
            return nursingCarePackageList;
        }

        private async Task<int> GetPackagesCount(ApprovedPackagesParameters parameters, int statusId)
        {
            var packageCount = 0;

            if (!parameters.PackageTypeId.HasValue || parameters.PackageTypeId == PackageTypesConstants.ResidentialCarePackageId)
            {
                packageCount += await _databaseContext.ResidentialCarePackages
                    .FilterApprovedResidentialCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
                    .Include(p => p.ResidentialCareApprovalHistories)
                    .Where(p => !parameters.ApproverId.HasValue ||
                                p.ResidentialCareApprovalHistories.Any(h => h.Creator.Id == parameters.ApproverId))
                    .CountAsync().ConfigureAwait(false);
            }

            if (!parameters.PackageTypeId.HasValue || parameters.PackageTypeId == PackageTypesConstants.NursingCarePackageId)
            {
                packageCount += await _databaseContext.NursingCarePackages
                    .FilterApprovedNursingCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
                    .Include(p => p.NursingCareApprovalHistories)
                    .Where(p => !parameters.ApproverId.HasValue ||
                                p.NursingCareApprovalHistories.Any(h => h.Creator.Id == parameters.ApproverId))
                    .CountAsync().ConfigureAwait(false);
            }

            //packageCount += await _databaseContext.HomeCarePackage
            //    .FilterApprovedHomeCareList(statusId, parameters.HackneyId, parameters.ClientName, parameters.SocialWorkerId)
            //    .CountAsync().ConfigureAwait(false);

            return packageCount;
        }
    }
}
