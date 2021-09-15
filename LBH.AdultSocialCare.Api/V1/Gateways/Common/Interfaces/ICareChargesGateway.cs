using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICareChargesGateway
    {
        Task<ProvisionalCareChargeAmountPlainDomain> GetUsingServiceUserIdAsync(Guid serviceUserId);

        Task<bool> UpdateCareChargeElementStatusAsync(Guid packageCareChargeId, Guid careElementId, int newElementStatusId, DateTimeOffset? newEndDate);

        Task<CareChargeElementPlainDomain> CheckCareChargeElementExistsAsync(Guid packageCareChargeId,
            Guid careElementId);

        Task<IEnumerable<CareChargeElementPlainDomain>> CreateCareChargeElementsAsync(IEnumerable<CareChargeElementPlainDomain> elementDomains);

        Task<PagedList<CareChargePackagesDomain>> GetCareChargePackages(CareChargePackagesParameters parameters);
    }
}
