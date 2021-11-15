using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetPayRunInvoiceUseCase
    {
        Task<PayRunInvoiceDetailViewResponse> GetDetailsAsync(Guid payRunId, Guid invoiceId);
    }
}
