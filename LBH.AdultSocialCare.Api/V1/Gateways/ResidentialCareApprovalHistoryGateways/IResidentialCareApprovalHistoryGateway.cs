using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways
{
    public interface IResidentialCareApprovalHistoryGateway
    {
        public Task<IEnumerable<ResidentialCareApprovalHistoryDomain>> ListAsync(Guid residentialCarePackageId);
    }
}
