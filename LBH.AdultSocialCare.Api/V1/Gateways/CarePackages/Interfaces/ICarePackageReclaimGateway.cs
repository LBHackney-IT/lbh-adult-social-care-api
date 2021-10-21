using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces
{
    public interface ICarePackageReclaimGateway
    {
        Task<CarePackageReclaimDomain> CreateAsync(CarePackageReclaim carePackageReclaim);
        Task<bool> UpdateAsync(CarePackageReclaimForUpdateDomain carePackageReclaimForUpdateDomain);
        Task<CarePackageReclaimDomain> GetAsync(Guid carePackageId, ReclaimType reclaimType);


        Task<bool> UpdateAsync(CarePackageReclaimUpdateDomain carePackageReclaimUpdateDomain);

        Task<CarePackageReclaim> GetAsync(Guid reclaimId);

        Task<CarePackageReclaimDomain> GetSingleAsync(Guid carePackageId, ReclaimType reclaimType);

        Task<List<CarePackageReclaim>> GetListAsync(IEnumerable<Guid> reclaimIds);

        Task<PagedList<CareChargePackagesDomain>> GetCareChargePackages(CareChargePackagesParameters parameters);

        Task<SinglePackageCareChargeDomain> GetSinglePackageCareCharge(Guid packageId);
    }
}
