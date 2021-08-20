using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageReclaimGateways
{
    public interface INursingCarePackageReclaimGateway
    {
        public Task<NursingCarePackageClaimDomain> CreateAsync(NursingCarePackageReclaim nursingCarePackageReclaim);

        public Task<IEnumerable<ReclaimAmountOptionDomain>> GetListOfAmountOptionAsync();

        public Task<IEnumerable<ReclaimCategoryDomain>>
            GetListOfPackageReclaimCategoryOptionAsync();

        public Task<IEnumerable<ReclaimFromDomain>> GetListOfPackageReclaimFromOptionAsync();
    }
}
