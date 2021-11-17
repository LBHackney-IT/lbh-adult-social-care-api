using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICareChargesGateway
    {
        Task<ProvisionalCareChargeAmountPlainDomain> GetUsingServiceUserIdAsync(Guid serviceUserId);
        Task<PagedList<CareChargePackagesDomain>> GetCareChargePackages(CareChargePackagesParameters parameters);
    }
}
