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
    public class GetAllHomeCareReclaimCategoryUseCase : IGetAllHomeCareReclaimCategoryUseCase
    {
        private readonly IHomeCarePackageReclaimGateway _gateway;

        public GetAllHomeCareReclaimCategoryUseCase(IHomeCarePackageReclaimGateway homeCarePackageReclaimGateway)
        {
            _gateway = homeCarePackageReclaimGateway;
        }

        public async Task<IEnumerable<HomeCarePackageReclaimCategoryResponse>> GetAllAsync()
        {
            var result = await _gateway.GetListOfPackageReclaimCategoryOptionAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
