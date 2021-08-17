using Common.Exceptions.CustomExceptions;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpServices.Services.Concrete
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IRestClient _restClient;

        private static readonly List<string> _allowedPayRunTypes = new List<string>
        {
            "ResidentialRecurring",
            "DirectPayments",
            "HomeCare",
            "ResidentialReleaseHolds",
            "DirectPaymentsReleaseHolds"
        };

        public TransactionsService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IEnumerable<DepartmentResponse>> GetPaymentDepartments()
        {
            return await _restClient
                .GetAsync<IEnumerable<DepartmentResponse>>(
                    "api/v1/departments/payment-departments",
                    "Cannot retrieve departments")
                .ConfigureAwait(false);
        }

        public async Task<Guid?> CreateResidentialRecurringPayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            return await CreateNewPayRun("ResidentialRecurring", payRunForCreationRequest).ConfigureAwait(false);
        }

        public async Task<Guid?> CreateDirectPaymentsPayRun(
            PayRunForCreationRequest payRunForCreationRequest)
        {
            return await CreateNewPayRun("DirectPayments", payRunForCreationRequest).ConfigureAwait(false);
        }

        public async Task<Guid?> CreateHomeCarePayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            return await CreateNewPayRun("HomeCare", payRunForCreationRequest).ConfigureAwait(false);
        }

        public async Task<Guid?> CreateResidentialReleaseHoldsPayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            return await CreateNewPayRun("ResidentialReleaseHolds", payRunForCreationRequest).ConfigureAwait(false);
        }

        public async Task<Guid?> CreateDirectPaymentsReleaseHoldsPayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            return await CreateNewPayRun("DirectPaymentsReleaseHolds", payRunForCreationRequest).ConfigureAwait(false);
        }

        public async Task<PayRunDateSummaryResponse> GetDateOfLastPayRun(string payRunType)
        {
            var correctPayRunType =
                _allowedPayRunTypes.Find(p => p.Equals(payRunType, StringComparison.OrdinalIgnoreCase));

            if (correctPayRunType == null)
            {
                throw new EntityNotFoundException("The pay run type is not valid. Please check and try again");
            }

            return await _restClient
                .GetAsync<PayRunDateSummaryResponse>(
                    $"api/v1/pay-runs/date-of-last-pay-run/{correctPayRunType}",
                    "Failed to fetch date of last pay run")
                .ConfigureAwait(false);
        }

        public async Task<PagedPayRunSummaryResponse> GetPayRunSummaryList(PayRunSummaryListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>
            {
                {
                    "pageNumber", $"{parameters.PageNumber}"
                },
                {
                    "pageSize", $"{parameters.PageSize}"
                },
                {
                    "payRunId", $"{parameters.PayRunId}"
                },
                {
                    "payRunTypeId", $"{parameters.PayRunTypeId}"
                },
                {
                    "payRunSubTypeId", $"{parameters.PayRunSubTypeId}"
                },
                {
                    "payRunStatusId", $"{parameters.PayRunStatusId}"
                },
                {
                    "dateFrom", parameters.DateFrom?.DateTimeOffsetToISOString()
                },
                {
                    "dateTo", parameters.DateTo?.DateTimeOffsetToISOString()
                }
            };

            var url = QueryHelpers.AddQueryString("api/v1/pay-runs/summary-list", queryParams);

            return await _restClient
                .GetAsync<PagedPayRunSummaryResponse>(url, "Cannot retrieve pay run summary list")
                .ConfigureAwait(false);
        }

        public async Task<PagedSupplierMinimalListResponse> GetUniqueSuppliersInPayRunUseCase(Guid payRunId,
            SupplierListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>
            {
                {
                    "pageNumber", $"{parameters.PageNumber}"
                },
                {
                    "pageSize", $"{parameters.PageSize}"
                },
                {
                    "searchTerm", $"{parameters.SearchTerm}"
                }
            };

            var url = QueryHelpers.AddQueryString($"api/v1/pay-runs/{payRunId}/unique-suppliers", queryParams);

            return await _restClient
                .GetAsync<PagedSupplierMinimalListResponse>(url, "Cannot retrieve Suppliers in pay run")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<ReleasedHoldsByTypeResponse>> GetReleasedHoldsCount(DateTimeOffset? fromDate = null,
            DateTimeOffset? toDate = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                {
                    "fromDate", $"{fromDate?.DateTimeOffsetToISOString()}"
                },
                {
                    "toDate", $"{toDate?.DateTimeOffsetToISOString()}"
                }
            };

            var url = QueryHelpers.AddQueryString("api/v1/pay-runs/released-holds-count", queryParams);

            return await _restClient
                .GetAsync<IEnumerable<ReleasedHoldsByTypeResponse>>(url, "Cannot retrieve released hold count")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<PackageTypeResponse>> GetUniquePackageTypesInPayRunUseCase(Guid payRunId)
        {
            return await _restClient
                .GetAsync<IEnumerable<PackageTypeResponse>>(
                    $"api/v1/pay-runs/{payRunId}/unique-package-types",
                    "Failed to retrieve package types in pay run")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InvoiceStatusResponse>> GetUniquePaymentStatusesInPayRunUseCase(Guid payRunId)
        {
            return await _restClient
                .GetAsync<IEnumerable<InvoiceStatusResponse>>(
                    $"api/v1/pay-runs/{payRunId}/unique-payment-statuses",
                    "Failed to retrieve payment statuses in pay run")
                .ConfigureAwait(false);
       }

        public async Task<IEnumerable<InvoiceResponse>> GetReleasedHoldsUseCase(DateTimeOffset? fromDate = null,
            DateTimeOffset? toDate = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                {
                    "fromDate", $"{fromDate?.DateTimeOffsetToISOString()}"
                },
                {
                    "toDate", $"{toDate?.DateTimeOffsetToISOString()}"
                }
            };

            var url = QueryHelpers.AddQueryString("api/v1/pay-runs/released-holds", queryParams);

            return await _restClient
                .GetAsync<IEnumerable<InvoiceResponse>>(url, "Failed to retrieve released holds")
                .ConfigureAwait(false);
        }

        public async Task<PayRunDetailsResponse> GetSinglePayRunDetailsUseCase(Guid payRunId,
            InvoiceListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>
            {
                {
                    "pageNumber", $"{parameters.PageNumber}"
                },
                {
                    "pageSize", $"{parameters.PageSize}"
                },
                {
                    "supplierId", parameters.SupplierId != null? $"{parameters.SupplierId}": ""
                },
                {
                    "serviceUserId", parameters.ServiceUserId != null? $"{parameters.ServiceUserId}": ""
                },
                {
                    "packageTypeId", parameters.PackageTypeId != null? $"{parameters.PackageTypeId}": ""
                },
                {
                    "invoiceStatusId", parameters.InvoiceStatusId != null? $"{parameters.InvoiceStatusId}": ""
                },
                {
                    "invoiceItemPaymentStatusId", parameters.InvoiceStatusId != null? $"{parameters.InvoiceStatusId}": ""
                },
                {
                    "searchTerm", parameters.InvoiceNumber != null? $"{parameters.InvoiceNumber}": ""
                },
                {
                    "dateFrom", parameters.DateFrom != null?$"{parameters.DateFrom?.DateTimeOffsetToISOString()}": ""
                },
                {
                    "dateTo", parameters.DateTo != null?$"{parameters.DateTo?.DateTimeOffsetToISOString()}": ""
                }
            };

            var url = QueryHelpers.AddQueryString($"api/v1/pay-runs/{payRunId}/details", queryParams);

            return await _restClient
                .GetAsync<PayRunDetailsResponse>(url, "Failed to retrieve pay run details")
                .ConfigureAwait(false);
        }

        public async Task<PayRunInsightsResponse> GetSinglePayRunInsightsUseCase(Guid payRunId)
        {
            return await _restClient
                .GetAsync<PayRunInsightsResponse>(
                    $"api/v1/pay-runs/{payRunId}/summary-insights",
                    "Failed to retrieve pay run insights")
                .ConfigureAwait(false);
        }

        public async Task<bool> SubmitPayRunForApprovalUseCase(Guid payRunId)
        {
            return await _restClient
                .GetAsync<bool>(
                    $"api/v1/pay-runs/{payRunId}/status/submit-for-approval",
                    "Failed to submit pay run for approval")
                .ConfigureAwait(false);
        }

        public async Task<bool> KickBackPayRunToDraftUseCase(Guid payRunId)
        {
            return await _restClient
                .GetAsync<bool>(
                    $"api/v1/pay-runs/{payRunId}/status/kick-back-to-draft",
                    "Failed to kick pay run back to draft")
                .ConfigureAwait(false);
        }

        public async Task<bool> ApprovePayRunForPaymentUseCase(Guid payRunId)
        {
            return await _restClient
                .GetAsync<bool>(
                    $"api/v1/pay-runs/{payRunId}/status/approve-pay-run",
                    "Failed to approve pay run")
                .ConfigureAwait(false);
        }

        public async Task<bool> ReleaseHeldInvoiceItemPaymentUseCase(
            ReleaseHeldInvoiceItemRequest releaseHeldInvoiceItemRequest)
        {
            return await _restClient
                .PutAsync<bool>(
                    "api/v1/pay-runs/release-held-invoice",
                    releaseHeldInvoiceItemRequest,
                    "Failed to release held invoice")
                .ConfigureAwait(false);
        }

        public async Task<bool> ReleaseHeldInvoiceItemPaymentListUseCase(
            IEnumerable<ReleaseHeldInvoiceItemRequest> releaseHeldInvoiceItemRequests)
        {
            return await _restClient
                .PutAsync<bool>(
                    "api/v1/pay-runs/release-held-invoice-list",
                    releaseHeldInvoiceItemRequests,
                    "Failed to release held invoice list")
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteDraftPayRunUseCase(Guid payRunId)
        {
            return await _restClient
                .DeleteAsync<bool>(
                    $"api/v1/pay-runs/{payRunId}",
                    "Failed to delete pay run")
                .ConfigureAwait(false);
        }

        public async Task<DisputedInvoiceFlatResponse> HoldInvoicePaymentUseCase(Guid payRunId, Guid invoiceId,
            DisputedInvoiceForCreationRequest disputedInvoiceForCreationRequest)
        {
            return await _restClient
                .PostAsync<DisputedInvoiceFlatResponse>(
                    $"api/v1/pay-runs/{payRunId}/invoices/{invoiceId}/hold-payment",
                    disputedInvoiceForCreationRequest,
                    "Failed to hold invoice")
                .ConfigureAwait(false);
        }

        public async Task<PagedHeldInvoiceResponse> GetHeldInvoicePaymentsUseCase(HeldInvoicePaymentParameters parameters)
        {
            var queryParams = new Dictionary<string, string>
            {
                {
                    "pageNumber", $"{parameters.PageNumber}"
                },
                {
                    "pageSize", $"{parameters.PageSize}"
                },
                {
                    "waitingOnId", parameters.WaitingOnId != null ? $"{parameters.WaitingOnId}" : ""
                },
                {
                    "supplierId", parameters.SupplierId != null ? $"{parameters.SupplierId}" : ""
                },
                {
                    "packageTypeId", parameters.PackageTypeId != null ? $"{parameters.PackageTypeId}" : ""
                },
                {
                    "serviceUserId", parameters.ServiceUserId != null ? $"{parameters.ServiceUserId}" : ""
                },
                {
                    "dateFrom", parameters.DateFrom != null ? parameters.DateFrom?.DateTimeOffsetToISOString() : ""
                },
                {
                    "dateTo", parameters.DateTo != null ? parameters.DateTo?.DateTimeOffsetToISOString() : ""
                }
            };

            var url = QueryHelpers.AddQueryString("api/v1/invoices/held-invoice-payments", queryParams);

            return await _restClient
                .GetAsync<PagedHeldInvoiceResponse>(url, "Failed to fetch held invoice payments")
                .ConfigureAwait(false);
        }

        public async Task<InvoiceResponse> CreateInvoiceUseCase(InvoiceForCreationRequest invoiceForCreationRequest)
        {
            return await _restClient
                .PostAsync<InvoiceResponse>(
                    "api/v1/invoices",
                    invoiceForCreationRequest,
                    "Failed to create invoice")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InvoiceResponse>> BatchCreateInvoicesUseCase(IEnumerable<InvoiceForCreationRequest> invoices)
        {
            return await _restClient
                .PostAsync<IEnumerable<InvoiceResponse>>(
                    "api/v1/invoices/batch",
                    invoices,
                    "Failed to create invoices")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InvoiceStatusResponse>> GetAllInvoiceStatusesUseCase()
        {
            return await _restClient
                .GetAsync<IEnumerable<InvoiceStatusResponse>>(
                    "api/v1/invoices/invoice-status-list",
                    "Failed to fetch invoice statuses")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InvoiceStatusResponse>> GetInvoicePaymentStatusesUseCase()
        {
            return await _restClient
                .GetAsync<IEnumerable<InvoiceStatusResponse>>(
                    "api/v1/invoices/invoice-payment-statuses",
                    "Failed to fetch invoice payment statuses")
                .ConfigureAwait(false);
        }

        public async Task<bool> AcceptInvoiceUseCase(Guid payRunId, Guid invoiceId)
        {
            return await _restClient
                .PutAsync<bool>(
                    $"api/v1/pay-runs/{payRunId}/invoices/{invoiceId}/accept-invoice", null,
                    "Failed to change invoice status")
                .ConfigureAwait(false);
        }

        public async Task<bool> RejectInvoiceUseCase(Guid payRunId, Guid invoiceId)
        {
            return await _restClient
                .PutAsync<bool>(
                    $"api/v1/pay-runs/{payRunId}/invoices/{invoiceId}/status/reject-invoice", null,
                    "Failed to change invoice status")
                .ConfigureAwait(false);
        }

        public async Task<BillResponse> CreateSupplierBillUseCase(BillCreationRequest billCreationRequest)
        {
            return await _restClient
                .PostAsync<BillResponse>(
                    "api/v1/bills",
                    billCreationRequest,
                    "Failed to create supplier bill")
                .ConfigureAwait(false);
        }

        public async Task<bool> PaySupplierBillUseCase(IEnumerable<long> supplierBillIds)
        {
            return await _restClient
                .PostAsync<bool>(
                    "api/v1/bills/pay",
                    supplierBillIds,
                    "Failed to pay supplier bill")
                .ConfigureAwait(false);
        }

        public async Task<PagedBillSummaryResponse> GetBillSummaryList(BillSummaryListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>
            {
                {
                    "pageNumber", $"{parameters.PageNumber}"
                },
                {
                    "pageSize", $"{parameters.PageSize}"
                },
                {
                    "packageId", $"{parameters.PackageId}"
                },
                {
                    "supplierId", $"{parameters.SupplierId}"
                },
                {
                    "billPaymentStatusId", $"{parameters.BillPaymentStatusId}"
                },
                {
                    "fromDate", parameters.FromDate?.DateTimeOffsetToISOString()
                },
                {
                    "toDate", parameters.ToDate?.DateTimeOffsetToISOString()
                }
            };

            var url = QueryHelpers.AddQueryString("api/v1/bills", queryParams);

            return await _restClient
                .GetAsync<PagedBillSummaryResponse>(url, "Cannot retrieve bills summary list")
                .ConfigureAwait(false);
        }

        public async Task<PagedSupplierResponse> GetSuppliersListUseCase(SupplierListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>
            {
                {
                    "pageNumber", $"{parameters.PageNumber}"
                },
                {
                    "pageSize", $"{parameters.PageSize}"
                },
                {
                    "searchTerm", $"{parameters.SearchTerm}"
                }
            };

            var url = QueryHelpers.AddQueryString("api/v1/suppliers", queryParams);

            return await _restClient
                .GetAsync<PagedSupplierResponse>(url, "Cannot retrieve Suppliers list")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<SupplierTaxRateResponse>> GetSupplierTaxRateUseCase(long supplierId)
        {
            return await _restClient
                .GetAsync<IEnumerable<SupplierTaxRateResponse>>(
                    $"api/v1/suppliers/{supplierId}/tax-rates",
                    "Failed to retrieve supplier tax rates")
                .ConfigureAwait(false);
        }

        public async Task<DisputedInvoiceChatResponse> CreatePayRunHeldChatUseCase(Guid payRunId, Guid invoiceId,
            DisputedInvoiceChatForCreationRequest disputedInvoiceChatForCreationRequest)
        {
            return await _restClient
                .PostAsync<DisputedInvoiceChatResponse>(
                    $"api/v1/pay-runs/{payRunId}/invoices/{invoiceId}/create-held-chat",
                    disputedInvoiceChatForCreationRequest,
                    "Failed to create disputed invoice chat")
                .ConfigureAwait(false);
        }

        public async Task<bool> AcceptInvoicesUseCase(Guid payRunId, InvoiceIdListRequest invoiceIdList)
        {
            return await _restClient
                .PutAsync<bool>(
                    $"api/v1/pay-runs/{payRunId}/invoices/accept-invoices",
                    invoiceIdList,
                    "Failed to change invoice status")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<PayRunTypeResponse>> GetAllPayRunTypesUseCase()
        {
            return await _restClient
                .GetAsync<IEnumerable<PayRunTypeResponse>>(
                    "api/v1/pay-runs/pay-run-types",
                    "Failed to retrieve pay run types")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<PayRunSubTypeResponse>> GetAllPayRunSubTypesUseCase()
        {
            return await _restClient
                .GetAsync<IEnumerable<PayRunSubTypeResponse>>(
                    "api/v1/pay-runs/pay-run-sub-types",
                    "Failed to retrieve pay run sub types")
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<PayRunStatusResponse>> GetAllUniquePayRunStatusesUseCase()
        {
            return await _restClient
                .GetAsync<IEnumerable<PayRunStatusResponse>>(
                    "api/v1/pay-runs/unique-pay-run-statuses",
                    "Failed to retrieve pay run statuses")
                .ConfigureAwait(false);
        }

        private async Task<Guid?> CreateNewPayRun(string payRunName, PayRunForCreationRequest payRunForCreationRequest)
        {
            return await _restClient
                .PostAsync<Guid?>(
                    $"api/v1/pay-runs/{payRunName}",
                    payRunForCreationRequest,
                    "Failed to create pay run")
                .ConfigureAwait(false);
        }
    }
}
