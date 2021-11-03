using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetPayRunDetailsUseCase
    {
        Task<PayRunDetailsViewResponse> ExecuteAsync(Guid payrunId);
    }
}
