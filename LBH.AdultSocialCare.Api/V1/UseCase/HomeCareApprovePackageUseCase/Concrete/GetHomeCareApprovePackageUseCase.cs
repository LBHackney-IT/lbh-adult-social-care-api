using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Concrete
{
    public class GetHomeCareApprovePackageUseCase : IGetHomeCareApprovePackageUseCase
    {
        private readonly IHomeCareApprovePackageGateway _homeCareApprovePackageGateway;

        public GetHomeCareApprovePackageUseCase(IHomeCareApprovePackageGateway homeCareApprovePackageGateway)
        {
            _homeCareApprovePackageGateway = homeCareApprovePackageGateway;
        }

        public async Task<HomeCareApprovePackageResponse> Execute(Guid homeCarePackageId)
        {
            var homeCareApprovePackage = await _homeCareApprovePackageGateway.GetAsync(homeCarePackageId).ConfigureAwait(false);
            return homeCareApprovePackage.ToResponse();
        }
    }
}
