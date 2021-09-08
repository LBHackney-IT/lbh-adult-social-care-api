using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICareChargesGateway
    {
        Task<ProvisionalCareChargeAmountPlainDomain> GetUsingServiceUserIdAsync(Guid serviceUserId);

        Task<CareChargeElementPlainDomain> CreateCareChargeElementAsync(CareChargeElementPlainDomain elementDomain);
    }
}
