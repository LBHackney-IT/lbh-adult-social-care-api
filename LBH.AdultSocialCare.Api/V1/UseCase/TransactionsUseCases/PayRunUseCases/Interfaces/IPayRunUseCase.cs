using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpServices.Models.Requests;

namespace LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces
{
    public interface IPayRunUseCase
    {
        Task<Guid?> CreateNewPayRunUseCase(string payRunType, PayRunForCreationRequest payRunForCreationRequest);

        Task<PagedPayRunSummaryResponse> GetPayRunSummaryListUseCase(PayRunSummaryListParameters parameters);

        Task<IEnumerable<ReleasedHoldsByTypeResponse>> GetReleasedHoldsCountUseCase(DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null);

        Task<IEnumerable<HeldInvoiceResponse>> GetHeldInvoicePaymentsUseCase();
    }
}
