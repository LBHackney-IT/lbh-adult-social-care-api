using System;
using System.Threading.Tasks;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Responses;

namespace LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces
{
    public interface IPayRunUseCase
    {
        Task<Guid?> CreateNewPayRunUseCase(string payRunType);
        Task<PagedPayRunSummaryResponse> GetPayRunSummaryListUseCase(PayRunSummaryListParameters parameters);
    }
}
