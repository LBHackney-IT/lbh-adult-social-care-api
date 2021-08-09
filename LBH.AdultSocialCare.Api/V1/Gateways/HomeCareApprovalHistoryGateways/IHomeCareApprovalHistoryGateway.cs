using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovalHistoryGateways
{
    public interface IHomeCareApprovalHistoryGateway
    {
        public Task<IEnumerable<HomeCareApprovalHistoryDomain>> ListAsync(Guid homeCarePackageId);

        public Task<HomeCareApprovalHistoryDomain>
            CreateAsync(HomeCareApprovalHistory homeCareApprovalHistory);
    }
}
