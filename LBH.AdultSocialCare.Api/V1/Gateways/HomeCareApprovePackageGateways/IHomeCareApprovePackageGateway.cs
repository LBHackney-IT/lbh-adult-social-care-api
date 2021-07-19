using LBH.AdultSocialCare.Api.V1.Domain.HomeCareApprovePackageDomains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovePackageGateways
{
    public interface IHomeCareApprovePackageGateway
    {
        public Task<HomeCareApprovePackageDomain> GetAsync(Guid homeCarePackageId);
    }
}
