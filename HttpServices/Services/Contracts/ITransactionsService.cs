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

        Task<Guid?> CreateResidentialRecurringPayRun(PayRunForCreationRequest payRunForCreationRequest);

        Task<Guid?> CreateDirectPaymentsPayRun(PayRunForCreationRequest payRunForCreationRequest);

        Task<Guid?> CreateHomeCarePayRun(PayRunForCreationRequest payRunForCreationRequest);

        Task<Guid?> CreateResidentialReleaseHoldsPayRun(PayRunForCreationRequest payRunForCreationRequest);

        Task<Guid?> CreateDirectPaymentsReleaseHoldsPayRun(PayRunForCreationRequest payRunForCreationRequest);

        Task<PayRunDateSummaryResponse> GetDateOfLastPayRun(string payRunType);

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

        Task<DisputedInvoiceFlatResponse> HoldInvoicePaymentUseCase(Guid payRunId, Guid invoiceId,
            DisputedInvoiceForCreationRequest disputedInvoiceForCreationRequest);

        Task<IEnumerable<HeldInvoiceResponse>> GetHeldInvoicePaymentsUseCase();

        Task<InvoiceResponse> CreateInvoiceUseCase(InvoiceForCreationRequest invoiceForCreationRequest);

        Task<IEnumerable<InvoiceStatusResponse>> GetAllInvoiceStatusesUseCase();

        Task<IEnumerable<InvoiceStatusResponse>> GetInvoicePaymentStatusesUseCase();

        Task<bool> AcceptInvoiceUseCase(Guid payRunId, Guid invoiceId);

        Task<BillResponse> CreateSupplierBillUseCase(BillCreationRequest billCreationRequest);

        Task<bool> PaySupplierBillUseCase(IEnumerable<long> supplierBillIds);

        Task<PagedBillSummaryResponse> GetBillSummaryList(BillSummaryListParameters parameters);

        Task<PagedSupplierResponse> GetSuppliersListUseCase(SupplierListParameters parameters);

        Task<IEnumerable<SupplierTaxRateResponse>> GetSupplierTaxRateUseCase(long supplierId);

        Task<DisputedInvoiceChatResponse> CreatePayRunHeldChatUseCase(Guid payRunId,
            DisputedInvoiceChatForCreationRequest disputedInvoiceChatForCreationRequest);

        Task<bool> AcceptInvoicesUseCase(Guid payRunId, InvoiceIdListRequest invoiceIdList);

        Task<IEnumerable<PayRunTypeResponse>> GetAllPayRunTypesUseCase();

        Task<IEnumerable<PayRunSubTypeResponse>> GetAllPayRunSubTypesUseCase();

        Task<IEnumerable<PayRunStatusResponse>> GetAllUniquePayRunStatusesUseCase();
    }
}
