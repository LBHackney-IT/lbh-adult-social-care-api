using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpServices.Services.Contracts
{
    public interface ITransactionsService
    {
        Task<IEnumerable<DepartmentResponse>> GetPaymentDepartments();

        Task<Guid?> CreateResidentialRecurringPayRun();

        Task<Guid?> CreateDirectPaymentsPayRun();

        Task<Guid?> CreateHomeCarePayRun();

        Task<Guid?> CreateResidentialReleaseHoldsPayRun();

        Task<Guid?> CreateDirectPaymentsReleaseHoldsPayRun();

        Task<PagedPayRunSummaryResponse> GetPayRunSummaryList(PayRunSummaryListParameters parameters);

        Task<PagedSupplierMinimalListResponse> GetUniqueSuppliersInPayRunUseCase(Guid payRunId, SupplierListParameters parameters);

        Task<IEnumerable<ReleasedHoldsByTypeResponse>> GetReleasedHoldsCount(DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null);

        Task<IEnumerable<PackageTypeResponse>> GetUniquePackageTypesInPayRunUseCase(Guid payRunId);

        Task<IEnumerable<InvoiceStatusResponse>> GetUniquePaymentStatusesInPayRunUseCase(Guid payRunId);

        Task<IEnumerable<InvoiceResponse>> GetReleasedHoldsUseCase(DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null);

        Task<PayRunDetailsResponse> GetSinglePayRunDetailsUseCase(Guid payRunId, InvoiceListParameters parameters);

        Task<PayRunInsightsResponse> GetSinglePayRunInsightsUseCase(Guid payRunId);

        Task<bool> SubmitPayRunForApprovalUseCase(Guid payRunId);

        Task<bool> KickBackPayRunToDraftUseCase(Guid payRunId);

        Task<bool> ApprovePayRunForPaymentUseCase(Guid payRunId);

        Task<bool> ReleaseHeldInvoiceItemPaymentUseCase(ReleaseHeldInvoiceItemRequest releaseHeldInvoiceItemRequest);

        Task<bool> ReleaseHeldInvoiceItemPaymentListUseCase(IEnumerable<ReleaseHeldInvoiceItemRequest> releaseHeldInvoiceItemRequests);

        Task<bool> DeleteDraftPayRunUseCase(Guid payRunId);
    }
}
