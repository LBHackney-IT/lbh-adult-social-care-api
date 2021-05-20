using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Concrete
{
    public class GetAllHomeCareReclaimFromUseCase : IGetAllHomeCareReclaimFromUseCase
    {
        private readonly IHomeCarePackageReclaimGateway _gateway;

        public GetAllHomeCareReclaimFromUseCase(IHomeCarePackageReclaimGateway homeCarePackageReclaimGateway)
        {
            _gateway = homeCarePackageReclaimGateway;
        }

        public async Task<IEnumerable<HomeCarePackageReclaimFromResponse>> GetAllAsync()
        {
            var result = await _gateway.GetListOfPackageReclaimFromOptionAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
