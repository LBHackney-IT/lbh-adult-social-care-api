using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
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
