using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface INursingCareApprovalHistoryGateway
    {
        public Task<IEnumerable<NursingCareApprovalHistoryDomain>> ListAsync(Guid nursingCarePackageId);

        public Task<NursingCareApprovalHistoryDomain>
            CreateAsync(NursingCareApprovalHistory nursingCareApprovalHistory);
    }
}
