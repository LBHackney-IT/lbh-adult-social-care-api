using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces
{
    public interface IDayCarePackageReclaimGateway
    {
        public Task<DayCarePackageClaimDomain> CreateAsync(DayCarePackageReclaim dayCarePackageReclaim);

        public Task<IEnumerable<ReclaimAmountOptionDomain>> GetListOfAmountOptionAsync();

        public Task<IEnumerable<ReclaimCategoryDomain>>
            GetListOfPackageReclaimCategoryOptionAsync();

        public Task<IEnumerable<ReclaimFromDomain>> GetListOfPackageReclaimFromOptionAsync();
    }
}
