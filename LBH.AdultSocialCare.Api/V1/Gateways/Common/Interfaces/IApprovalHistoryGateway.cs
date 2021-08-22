using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IApprovalHistoryGateway
    {
        public Task<IEnumerable<HomeCareApprovalHistoryDomain>> ListAsync(Guid homeCarePackageId);
    }
}
