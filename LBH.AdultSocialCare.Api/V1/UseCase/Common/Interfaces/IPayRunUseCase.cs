using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IPayRunUseCase
    {
        Task<Guid?> CreateNewPayRunUseCase(string payRunType, PayRunForCreationRequest payRunForCreationRequest);

        Task<PagedPayRunSummaryResponse> GetPayRunSummaryListUseCase(PayRunSummaryListParameters parameters);

        Task<IEnumerable<ReleasedHoldsByTypeResponse>> GetReleasedHoldsCountUseCase(DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null);

        Task<PagedHeldInvoiceResponse> GetHeldInvoicePaymentsUseCase(HeldInvoicePaymentParameters parameters);
        Task<PayRunDetailsResponse> GetSinglePayRunDetailsUseCase(Guid payRunId, InvoiceListParameters parameters);
    }
}
