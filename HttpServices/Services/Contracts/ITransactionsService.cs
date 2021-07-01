using HttpServices.Models.Features.RequestFeatures;
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
    }
}
