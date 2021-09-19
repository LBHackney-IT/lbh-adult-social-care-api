using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICareChargesGateway
    {
        Task<IEnumerable<PackageCareCharge>> GetCareChargesAsync(IEnumerable<Guid> packageIds);

        Task<ProvisionalCareChargeAmountPlainDomain> GetUsingServiceUserIdAsync(Guid serviceUserId);

        Task<bool> UpdateCareChargeElementStatusAsync(Guid packageCareChargeId, Guid careElementId, int newElementStatusId, DateTimeOffset? newEndDate);

        Task<CareChargeElementPlainDomain> CheckCareChargeElementExistsAsync(Guid packageCareChargeId, Guid careElementId);

        Task<IEnumerable<CareChargeElementPlainDomain>> CreateCareChargeElementsAsync(IEnumerable<CareChargeElementPlainDomain> elementDomains);

        Task RefreshCareChargeElementsPaidUpToDate(IEnumerable<CareChargeElement> elements, DateTimeOffset paidUpTo);

        Task<CareChargeElementPlainDomain> CreateCareChargeElementAsync(CareChargeElement careChargeElement);

        Task<PagedList<CareChargePackagesDomain>> GetCareChargePackages(CareChargePackagesParameters parameters);

        Task<SinglePackageCareChargeDomain> GetSinglePackageCareCharge(Guid packageId, int packageTypeId);
    }
}
