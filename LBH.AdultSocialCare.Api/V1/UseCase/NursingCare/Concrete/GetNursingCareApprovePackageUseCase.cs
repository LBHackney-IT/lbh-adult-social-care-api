using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class GetNursingCareApprovePackageUseCase : IGetNursingCareApprovePackageUseCase
    {
        private readonly INursingCareApprovePackageGateway _nursingCareApprovePackageGateway;

        public GetNursingCareApprovePackageUseCase(INursingCareApprovePackageGateway nursingCareApprovePackageGateway)
        {
            _nursingCareApprovePackageGateway = nursingCareApprovePackageGateway;
        }

        public async Task<NursingCareApprovePackageResponse> Execute(Guid nursingCarePackageId)
        {
            var nursingCareApprovePackage = await _nursingCareApprovePackageGateway.GetAsync(nursingCarePackageId).ConfigureAwait(false);
            return nursingCareApprovePackage.ToResponse();
        }
    }
}