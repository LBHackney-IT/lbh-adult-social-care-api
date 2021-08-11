using LBH.AdultSocialCare.Api.V1.Boundary.InvoiceBoundary.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces
{
    public interface IGetNursingCareInvoiceDetailUseCase
    {
        Task<InvoiceResponse> GetNursingCareInvoiceDetail(Guid nursingCarePackageId);
    }
}
