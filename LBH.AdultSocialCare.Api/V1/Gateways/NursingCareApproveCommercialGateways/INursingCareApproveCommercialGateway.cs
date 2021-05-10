using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApproveCommercialDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways
{
    public interface INursingCareApproveCommercialGateway
    {
        public Task<NursingCareApproveCommercialDomain> GetAsync(Guid nursingCarePackageId);
    }
}
