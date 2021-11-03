using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces
{
    public interface ICarePackageReclaimGateway
    {
        Task CreateAsync(CarePackageReclaim carePackageReclaim);

        Task<bool> UpdateAsync(CarePackageReclaimUpdateDomain carePackageReclaimUpdateDomain);

        Task<CarePackageReclaim> GetAsync(Guid reclaimId);

        Task<CarePackageReclaimDomain> GetSingleAsync(Guid carePackageId, ReclaimType reclaimType);

        Task<List<CarePackageReclaim>> GetListAsync(Guid packageId, ReclaimType? reclaimType, ReclaimSubType? reclaimSubType);

        Task<List<CarePackageReclaim>> GetListAsync(IEnumerable<Guid> reclaimIds);

        Task<SinglePackageCareChargeDomain> GetSinglePackageCareCharge(Guid packageId);
    }
}
