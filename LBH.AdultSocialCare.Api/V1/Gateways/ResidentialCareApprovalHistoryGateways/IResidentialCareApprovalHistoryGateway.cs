using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways
{
    public interface IResidentialCareApprovalHistoryGateway
    {
        public Task<IEnumerable<ResidentialCareApprovalHistoryDomain>> ListAsync(Guid residentialCarePackageId);

        public Task<ResidentialCareApprovalHistoryDomain>
            CreateAsync(ResidentialCareApprovalHistory residentialCareApprovalHistory);
    }
}
