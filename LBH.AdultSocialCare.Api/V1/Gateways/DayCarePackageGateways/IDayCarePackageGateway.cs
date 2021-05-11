using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways
{
    public interface IDayCarePackageGateway
    {
        Task<Guid> CreateDayCarePackage(DayCarePackage dayCarePackage);
        Task<Guid> CreateDayCarePackageHistory(DayCareApprovalHistory dayCareApprovalHistory);
        Task<DayCarePackageDomain> UpdateDayCarePackage(DayCarePackageForUpdateDomain dayCarePackageForUpdate);
        Task<DayCarePackageDomain> GetDayCarePackage(Guid dayCarePackageId);
        Task<Guid> UpdateDayCarePackageStatus(Guid dayCarePackageId, int newStatusId);
        Task<DayCarePackageForApprovalDetailsDomain> GetDayCarePackageForApprovalDetails(Guid dayCarePackageId);
        Task<IEnumerable<DayCarePackageDomain>> GetDayCarePackageList();
    }
}
