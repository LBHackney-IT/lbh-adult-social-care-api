using System;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IHoldInvoiceUseCase
    {
        Task<HeldInvoiceFlatResponse> ExecuteAsync(Guid payRunId, Guid invoiceId, HeldInvoiceCreationDomain heldInvoiceCreationDomain);
    }
}
