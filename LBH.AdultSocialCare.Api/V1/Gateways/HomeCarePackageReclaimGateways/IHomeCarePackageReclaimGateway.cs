using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCarePackageReclaimGateways
{
    public interface IHomeCarePackageReclaimGateway
    {
        public Task<HomeCarePackageClaimDomain> CreateAsync(HomeCarePackageReclaim homeCarePackageReclaim);

        public Task<IEnumerable<HomeCarePackageReclaimAmountOptionDomain>> GetListOfAmountOptionAsync();

        public Task<IEnumerable<HomeCarePackageReclaimCategoryDomain>>
            GetListOfPackageReclaimCategoryOptionAsync();

        public Task<IEnumerable<HomeCarePackageReclaimFromDomain>> GetListOfPackageReclaimFromOptionAsync();
    }
}
