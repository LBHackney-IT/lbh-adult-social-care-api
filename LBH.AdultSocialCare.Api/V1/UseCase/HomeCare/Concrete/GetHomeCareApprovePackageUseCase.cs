using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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