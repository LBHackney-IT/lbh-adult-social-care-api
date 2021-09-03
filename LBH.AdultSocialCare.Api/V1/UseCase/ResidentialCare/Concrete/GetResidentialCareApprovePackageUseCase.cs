using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
{
    public class GetResidentialCareApprovePackageUseCase : IGetResidentialCareApprovePackageUseCase
    {
        private readonly IResidentialCareApprovePackageGateway _residentialCareApprovePackageGateway;

        public GetResidentialCareApprovePackageUseCase(IResidentialCareApprovePackageGateway residentialCareApprovePackageGateway)
        {
            _residentialCareApprovePackageGateway = residentialCareApprovePackageGateway;
        }

        public async Task<ResidentialCareApprovePackageResponse> Execute(Guid residentialCarePackageId)
        {
            var residentialCareApprovePackage = await _residentialCareApprovePackageGateway.GetAsync(residentialCarePackageId).ConfigureAwait(false);
            return residentialCareApprovePackage.ToResponse();
        }
    }
}
