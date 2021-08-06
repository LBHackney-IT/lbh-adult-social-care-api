using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ApprovalHistoryGateways
{
    public interface IApprovalHistoryGateway
    {
        public Task<IEnumerable<HomeCareApprovalHistoryDomain>> ListAsync(Guid homeCarePackageId);
    }
}
