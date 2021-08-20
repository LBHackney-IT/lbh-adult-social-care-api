using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovePackageGateways
{
    public interface INursingCareApprovePackageGateway
    {
        public Task<NursingCareApprovePackageDomain> GetAsync(Guid nursingCarePackageId);
    }
}
