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
        private readonly ICareChargesGateway _careChargesGateway;

        public GetSinglePackageCareChargeUseCase(ICareChargesGateway careChargesGateway)
        {
            _careChargesGateway = careChargesGateway;
        }

        public async Task<SinglePackageCareChargeResponse> GetSinglePackageCareCharge(Guid packageId, int packageTypeId)
        {
            var singlePackageCareCharge = await _careChargesGateway.GetSinglePackageCareCharge(packageId, packageTypeId).ConfigureAwait(false);
            return singlePackageCareCharge.ToResponse();
        }
    }
}
