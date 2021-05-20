using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Concrete
{
    public class GetAllReclaimFromUseCase : IGetAllReclaimFromUseCase
    {
        private readonly IHomeCarePackageReclaimGateway _gateway;

        public GetAllReclaimFromUseCase(IHomeCarePackageReclaimGateway homeCarePackageReclaimGateway)
        {
            _gateway = homeCarePackageReclaimGateway;
        }

        public async Task<IEnumerable<ReclaimFromResponse>> GetAllAsync()
        {
            var result = await _gateway.GetListOfPackageReclaimFromOptionAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
