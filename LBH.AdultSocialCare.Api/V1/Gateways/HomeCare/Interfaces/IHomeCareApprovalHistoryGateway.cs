using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces
{
    public interface IHomeCareApprovalHistoryGateway
    {
        public Task<IEnumerable<HomeCareApprovalHistoryDomain>> ListAsync(Guid homeCarePackageId);

        public Task<HomeCareApprovalHistoryDomain>
            CreateAsync(HomeCareApprovalHistory homeCareApprovalHistory);
    }
}
