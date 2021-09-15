using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICancelOrEndCareChargeElementUseCase
    {
        Task<bool> ExecuteCancelAsync(Guid packageCareChargeId, Guid careElementId);

        Task<bool> ExecuteEndAsync(Guid packageCareChargeId, Guid careElementId, DateTimeOffset newEndDate);
    }
}
