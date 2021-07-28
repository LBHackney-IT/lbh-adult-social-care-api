using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.InvoiceBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces;

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
