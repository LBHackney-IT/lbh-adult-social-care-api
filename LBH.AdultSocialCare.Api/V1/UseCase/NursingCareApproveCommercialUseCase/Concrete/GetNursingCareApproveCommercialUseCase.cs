using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApproveCommercialBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Concrete
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
