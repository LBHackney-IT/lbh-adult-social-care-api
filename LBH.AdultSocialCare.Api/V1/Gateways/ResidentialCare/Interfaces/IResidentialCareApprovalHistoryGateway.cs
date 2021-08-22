using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces
{
    public interface IResidentialCareApprovalHistoryGateway
    {
        public Task<IEnumerable<ResidentialCareApprovalHistoryDomain>> ListAsync(Guid residentialCarePackageId);

        public Task<ResidentialCareApprovalHistoryDomain>
            CreateAsync(ResidentialCareApprovalHistory residentialCareApprovalHistory);
    }
}
