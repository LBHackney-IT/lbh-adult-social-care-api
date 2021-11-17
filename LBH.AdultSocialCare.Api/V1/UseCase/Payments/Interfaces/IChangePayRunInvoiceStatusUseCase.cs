using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IChangePayRunInvoiceStatusUseCase
    {
        Task<bool> ExecuteAsync(Guid payRunId, Guid payRunInvoiceId, InvoiceStatus newStatus);
    }
}
