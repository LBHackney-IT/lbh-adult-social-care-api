using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageReclaimGateways
{
    public interface INursingCarePackageReclaimGateway
    {
        public Task<NursingCarePackageClaimDomain> CreateAsync(NursingCarePackageReclaim nursingCarePackageReclaim);

        public Task<IEnumerable<HomeCarePackageReclaimAmountOptionDomain>> GetListOfAmountOptionAsync();

        public Task<IEnumerable<HomeCarePackageReclaimCategoryDomain>>
            GetListOfPackageReclaimCategoryOptionAsync();

        public Task<IEnumerable<HomeCarePackageReclaimFromDomain>> GetListOfPackageReclaimFromOptionAsync();
    }
}
