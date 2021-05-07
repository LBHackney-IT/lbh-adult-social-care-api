using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovePackageGateways
{
    public interface INursingCareApprovePackageGateway
    {
        public Task<NursingCareApprovePackageDomain> GetAsync(Guid homeCarePackageId);
    }
}
