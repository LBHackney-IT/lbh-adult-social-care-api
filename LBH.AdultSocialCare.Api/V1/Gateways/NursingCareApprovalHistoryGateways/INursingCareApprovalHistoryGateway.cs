using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways
{
    public interface INursingCareApprovalHistoryGateway
    {
        public Task<IEnumerable<NursingCareApprovalHistoryDomain>> ListAsync(Guid nursingCarePackageId);
    }
}
