using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICareChargeUseCase
    {
        Task<ProvisionalCareChargeAmountPlainResponse> GetUsingServiceUserIdAsync(Guid serviceUserId);
    }
}
