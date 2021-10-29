using System;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
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
