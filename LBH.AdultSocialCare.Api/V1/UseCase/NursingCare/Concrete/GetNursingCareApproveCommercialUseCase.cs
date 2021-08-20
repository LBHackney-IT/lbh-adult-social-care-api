using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class GetNursingCareApproveCommercialUseCase : IGetNursingCareApproveCommercialUseCase
    {
        private readonly INursingCareApproveCommercialGateway _nursingCareApproveCommercialGateway;

        public GetNursingCareApproveCommercialUseCase(INursingCareApproveCommercialGateway nursingCareApproveCommercialGateway)
        {
            _nursingCareApproveCommercialGateway = nursingCareApproveCommercialGateway;
        }

        public async Task<NursingCareApproveCommercialResponse> Execute(Guid nursingCarePackageId)
        {
            var nursingCareApproveCommercial = await _nursingCareApproveCommercialGateway.GetAsync(nursingCarePackageId).ConfigureAwait(false);
            return nursingCareApproveCommercial.ToResponse();
        }
    }
}
