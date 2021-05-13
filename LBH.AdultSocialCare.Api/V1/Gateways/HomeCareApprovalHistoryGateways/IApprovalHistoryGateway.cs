using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovalHistoryGateways
{
    public interface IApprovalHistoryGateway
    {
        public Task<IEnumerable<HomeCareApprovalHistoryDomain>> ListAsync(Guid homeCarePackageId);
    }
}
