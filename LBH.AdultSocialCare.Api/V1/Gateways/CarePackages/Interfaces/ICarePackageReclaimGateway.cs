using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

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
