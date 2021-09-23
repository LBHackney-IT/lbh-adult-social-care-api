using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetCarePackageDetailsUseCase : IGetCarePackageDetailsUseCase
    {
        private readonly ICarePackageDetailGateway _carePackageDetailGateway;
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;
        public GetCarePackageDetailsUseCase(ICarePackageDetailGateway carePackageDetailGateway, ICarePackageReclaimGateway carePackageReclaimGateway)
        {
            _carePackageDetailGateway = carePackageDetailGateway;
            _carePackageReclaimGateway = carePackageReclaimGateway;
        }

        public Task<IEnumerable<CarePackageDetailResponse>> GetCarePackageDetails(Guid carePackageId)
        {
            /*
             * TODO: Implement this after finalizing design
             * 
             * 1.  Get CarePackageDetail and CarePackageReclaim
             * 2.  Group CarePackageReclaim by type (FNC, CareCharges)
             * 
             */
            throw new NotImplementedException();
        }
    }
}
