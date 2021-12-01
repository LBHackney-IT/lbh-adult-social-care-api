using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IChangePayRunInvoiceStatusUseCase
    {
        Task<bool> ExecuteAsync(Guid payRunId, Guid payRunInvoiceId, InvoiceStatus newStatus);

        Task<bool> ReleaseInvoiceAsync(Guid payRunId, Guid payRunInvoiceId);
    }
}
