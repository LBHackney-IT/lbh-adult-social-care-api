using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetPayRunInsightsUseCase
    {
        Task<PayRunInsightsResponse> GetAsync(Guid payRunId);
    }
}
