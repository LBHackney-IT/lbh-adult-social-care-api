using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SubmittedPackageRequestsGateways
{
    public class SubmittedPackageRequestsGateway : ISubmittedPackageRequestsGateway
    {
        private readonly DatabaseContext _databaseContext;

        public SubmittedPackageRequestsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<PagedList<SubmittedPackageRequestsDomain>> GetSubmittedPackageRequests(SubmittedPackageRequestParameters parameters)
        {
            var submittedPackageCount = await GetPackagesCount(parameters).ConfigureAwait(false);
            var packageList = await GetPackagesList(parameters).ConfigureAwait(false);

            var paginatedPackageList = packageList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return PagedList<SubmittedPackageRequestsDomain>.ToPagedList(paginatedPackageList, submittedPackageCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<IEnumerable<StatusDomain>> GetSubmittedPackageRequestsStatus()
        {
            var res = await _databaseContext.PackageStatuses
                .Where(x => x.Id <= ApprovalHistoryConstants.PackageApprovedId)
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        private async Task<List<SubmittedPackageRequestsDomain>> GetPackagesList(SubmittedPackageRequestParameters parameters)
        {
            var packageList = new List<SubmittedPackageRequestsDomain>();

            var homeCare = await GetHomeCarePackages(parameters).ConfigureAwait(false);
            packageList.AddRange(homeCare);

            var residentialCare = await GetResidentialCarePackages(parameters).ConfigureAwait(false);
            packageList.AddRange(residentialCare);

            var nursingCare = await GetNursingPackages(parameters).ConfigureAwait(false);
            packageList.AddRange(nursingCare);

            var dayCare = await GetDayCarePackages(parameters).ConfigureAwait(false);
            packageList.AddRange(dayCare);

            return packageList;
        }

        private async Task<List<SubmittedPackageRequestsDomain>> GetResidentialCarePackages(SubmittedPackageRequestParameters parameters)
        {
            var residentialCarePackageList = await _databaseContext.ResidentialCarePackages
                .Where(x => x.StatusId <= ApprovalHistoryConstants.PackageApprovedId)
                .FilterResidentialCareList(parameters.StatusId, parameters.ClientId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.ResidentialCareApprovalHistories)
                .Select(rc => new SubmittedPackageRequestsDomain()
                {
                    PackageId = rc.Id,
                    ClientId = (Guid) rc.ClientId,
                    Client = $"{rc.Client.FirstName} {rc.Client.MiddleName} {rc.Client.LastName}",
                    DateOfBirth = rc.Client.DateOfBirth,
                    CategoryId = PackageTypesConstants.ResidentialCarePackageId,
                    Category = PackageTypesConstants.ResidentialCarePackage,
                    StatusName = rc.Status.StatusName,
                    Approver = rc.ResidentialCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageApprovedId)
                        .Select(x => $"{x.Creator.Name}").SingleOrDefault(),
                    SubmittedDaysAgo =
                        rc.ResidentialCareApprovalHistories
                            .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                            .Select(x => DateTimeOffset.Now.Date.Subtract(x.ApprovedDate.Date).Days).SingleOrDefault(),
                    PrimarySupportReason = ""
                })
                .ToListAsync().ConfigureAwait(false);
            return residentialCarePackageList;
        }

        private async Task<List<SubmittedPackageRequestsDomain>> GetHomeCarePackages(SubmittedPackageRequestParameters parameters)
        {
            var homeCarePackageList = await _databaseContext.HomeCarePackage
                .Where(x => x.StatusId <= ApprovalHistoryConstants.PackageApprovedId)
                .FilterHomeCareList(parameters.StatusId, parameters.ClientId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.HomeCareApprovalHistories)
                .Select(hp => new SubmittedPackageRequestsDomain()
                {
                    PackageId = hp.Id,
                    ClientId = hp.ClientId,
                    Client = $"{hp.Client.FirstName} {hp.Client.MiddleName} {hp.Client.LastName}",
                    DateOfBirth = hp.Client.DateOfBirth,
                    CategoryId = PackageTypesConstants.HomeCarePackageId,
                    Category = PackageTypesConstants.HomeCarePackage,
                    StatusName = hp.Status.StatusName,
                    Approver = hp.HomeCareApprovalHistories
                        .Where(x => x.StatusId == ApprovalHistoryConstants.PackageApprovedId)
                        .Select(x => $"{x.Creator.Name}").SingleOrDefault(),
                    SubmittedDaysAgo =
                        hp.HomeCareApprovalHistories
                            .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                            .Select(x => DateTimeOffset.Now.Date.Subtract(x.ApprovedDate.Date).Days).SingleOrDefault(),
                    PrimarySupportReason = ""
                })
                .ToListAsync().ConfigureAwait(false);
            return homeCarePackageList;
        }

        private async Task<List<SubmittedPackageRequestsDomain>> GetNursingPackages(SubmittedPackageRequestParameters parameters)
        {
            return await _databaseContext.NursingCarePackages
                .Where(x => x.StatusId <= ApprovalHistoryConstants.PackageApprovedId)
                .FilterNursingCareList(parameters.StatusId, parameters.ClientId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.NursingCareApprovalHistories)
                .Select(nc => new SubmittedPackageRequestsDomain()
                {
                    PackageId = nc.Id,
                    ClientId = (Guid) nc.ClientId,
                    Client = $"{nc.Client.FirstName} {nc.Client.MiddleName} {nc.Client.LastName}",
                    DateOfBirth = nc.Client.DateOfBirth,
                    CategoryId = PackageTypesConstants.NursingCarePackageId,
                    Category = PackageTypesConstants.NursingCarePackage,
                    StatusName = nc.Status.StatusName,
                    Approver = nc.NursingCareApprovalHistories.Where(x => x.StatusId == ApprovalHistoryConstants.PackageApprovedId).
                        Select(x => $"{x.Creator.Name}").SingleOrDefault(),
                    SubmittedDaysAgo =
                        nc.NursingCareApprovalHistories
                            .Where(x => x.StatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                            .Select(x => DateTimeOffset.Now.Date.Subtract(x.ApprovedDate.Date).Days).SingleOrDefault(),
                    PrimarySupportReason = ""
                })
                .ToListAsync().ConfigureAwait(false);
        }

        private async Task<List<SubmittedPackageRequestsDomain>> GetDayCarePackages(SubmittedPackageRequestParameters parameters)
        {
            return await _databaseContext.DayCarePackages
                .Where(x => x.StatusId <= ApprovalHistoryConstants.PackageApprovedId)
                .FilterDayCareList(parameters.StatusId, parameters.ClientId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.DayCareApprovalHistories)
                .Select(dc => new SubmittedPackageRequestsDomain()
                {
                    PackageId = dc.DayCarePackageId,
                    ClientId = dc.ClientId,
                    Client = $"{dc.Client.FirstName} {dc.Client.MiddleName} {dc.Client.LastName}",
                    DateOfBirth = dc.Client.DateOfBirth,
                    CategoryId = PackageTypesConstants.DayCarePackageId,
                    Category = PackageTypesConstants.DayCarePackage,
                    StatusName = dc.Status.StatusName,
                    Approver = dc.DayCareApprovalHistories.Where(x => x.PackageStatusId == ApprovalHistoryConstants.PackageApprovedId).
                        Select(x => $"{x.Creator.Name}").SingleOrDefault(),
                    SubmittedDaysAgo =
                        dc.DayCareApprovalHistories
                            .Where(x => x.PackageStatusId == ApprovalHistoryConstants.SubmittedForApprovalId)
                            .Select(x => DateTimeOffset.Now.Date.Subtract(x.DateCreated.Date).Days).SingleOrDefault(),
                    PrimarySupportReason = ""
                })
                .ToListAsync().ConfigureAwait(false);
        }

        private async Task<int> GetPackagesCount(SubmittedPackageRequestParameters parameters)
        {
            var packageCount = 0;
            packageCount += await _databaseContext.ResidentialCarePackages
                .Where(x => x.StatusId <= ApprovalHistoryConstants.PackageApprovedId)
                .FilterResidentialCareList(parameters.StatusId, parameters.ClientId)
                .CountAsync()
                .ConfigureAwait(false);

            packageCount += await _databaseContext.NursingCarePackages
                .Where(x => x.StatusId <= ApprovalHistoryConstants.PackageApprovedId)
                .FilterNursingCareList(parameters.StatusId, parameters.ClientId)
                .CountAsync().ConfigureAwait(false);

            packageCount += await _databaseContext.DayCarePackages
                .Where(x => x.StatusId <= ApprovalHistoryConstants.PackageApprovedId)
                .FilterDayCareList(parameters.StatusId, parameters.ClientId)
                .CountAsync().ConfigureAwait(false);

            packageCount += await _databaseContext.HomeCarePackage
                .Where(x => x.StatusId <= ApprovalHistoryConstants.PackageApprovedId)
                .FilterHomeCareList(parameters.StatusId, parameters.ClientId)
                .CountAsync().ConfigureAwait(false);

            return packageCount;
        }
    }
}
