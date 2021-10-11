using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetSinglePackageCareChargeUseCase : IGetSinglePackageCareChargeUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;

        public GetSinglePackageCareChargeUseCase(ICarePackageReclaimGateway carePackageReclaimGateway)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
        }

        public async Task<SinglePackageCareChargeResponse> GetSinglePackageCareCharge(Guid packageId)
        {
            var singlePackageCareCharge = await _carePackageReclaimGateway.GetSinglePackageCareCharge(packageId).ConfigureAwait(false);
            return singlePackageCareCharge.ToResponse();
        }
    }
}
