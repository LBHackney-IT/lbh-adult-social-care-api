using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Concrete
{
    public class GetNursingCareInvoiceDetailUseCase : IGetNursingCareInvoiceDetailUseCase
    {
        private readonly INursingCareApproveCommercialGateway _nursingCareApproveCommercialGateway;

        public GetNursingCareInvoiceDetailUseCase(INursingCareApproveCommercialGateway nursingCareApproveCommercialGateway)
        {
            _nursingCareApproveCommercialGateway = nursingCareApproveCommercialGateway;
        }

        public async Task<InvoiceResponse> GetNursingCareInvoiceDetail(Guid nursingCarePackageId)
        {
            var nursingCareInvoiceDetail = await _nursingCareApproveCommercialGateway.GetInvoiceDetail(nursingCarePackageId).ConfigureAwait(false);
            return nursingCareInvoiceDetail.ToResponse();
        }
    }
}
