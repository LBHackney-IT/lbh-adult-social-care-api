using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCareApprovePackageGateways
{
    public interface IDayCareApprovePackageGateway
    {
        public Task<DayCareApprovePackageDomain> GetAsync(Guid dayCarePackageId);
    }
}
