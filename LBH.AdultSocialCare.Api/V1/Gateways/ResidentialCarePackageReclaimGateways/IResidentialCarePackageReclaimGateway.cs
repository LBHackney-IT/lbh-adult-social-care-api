using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ReclaimsDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageReclaimGateways
{
    public interface IResidentialCarePackageReclaimGateway
    {
        public Task<ResidentialCarePackageClaimDomain> CreateAsync(ResidentialCarePackageReclaim residentialCarePackageReclaim);

        public Task<IEnumerable<ReclaimAmountOptionDomain>> GetListOfAmountOptionAsync();

        public Task<IEnumerable<ReclaimCategoryDomain>>
            GetListOfPackageReclaimCategoryOptionAsync();

        public Task<IEnumerable<ReclaimFromDomain>> GetListOfPackageReclaimFromOptionAsync();
    }
}
