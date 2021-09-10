using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICancelInvoiceElementUseCase
    {
        Task<bool> ExecuteAsync(Guid packageCareChargeId, Guid careElementId);
    }
}
