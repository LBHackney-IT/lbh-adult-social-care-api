using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface IGetNursingCareInvoiceDetailUseCase
    {
        Task<InvoiceResponse> GetNursingCareInvoiceDetail(Guid nursingCarePackageId);
    }
}