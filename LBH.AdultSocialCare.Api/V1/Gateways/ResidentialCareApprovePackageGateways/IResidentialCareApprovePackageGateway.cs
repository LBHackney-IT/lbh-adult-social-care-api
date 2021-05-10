using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareApprovePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovePackageGateways
{
    public interface IResidentialCareApprovePackageGateway
    {
        public Task<ResidentialCareApprovePackageDomain> GetAsync(Guid residentialCarePackageId);
    }
}
