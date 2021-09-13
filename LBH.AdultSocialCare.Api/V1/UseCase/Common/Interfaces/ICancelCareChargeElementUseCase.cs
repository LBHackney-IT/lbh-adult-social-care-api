using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICancelCareChargeElementUseCase
    {
        Task<bool> ExecuteAsync(Guid packageCareChargeId, Guid careElementId);
    }
}
