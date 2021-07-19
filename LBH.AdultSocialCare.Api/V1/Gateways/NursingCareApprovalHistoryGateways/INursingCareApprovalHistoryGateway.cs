using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways
{
    public interface INursingCareApprovalHistoryGateway
    {
        public Task<IEnumerable<NursingCareApprovalHistoryDomain>> ListAsync(Guid nursingCarePackageId);

        public Task<NursingCareApprovalHistoryDomain>
            CreateAsync(NursingCareApprovalHistory nursingCareApprovalHistory);
    }
}
