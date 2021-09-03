using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IPackageCostClaimersGateway
    {
        Task<IEnumerable<FundedNursingCareCollectorDomain>> GetFundedNursingCareCollectorsAsync();
    }
}
