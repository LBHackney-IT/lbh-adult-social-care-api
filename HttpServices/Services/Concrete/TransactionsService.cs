using Common.Extensions;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;

namespace HttpServices.Services.Concrete
{
    public class TransactionsService : ITransactionsService
    {
        private readonly HttpClient _httpClient;

        public TransactionsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DepartmentResponse>> GetPaymentDepartments()
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/departments/payment-departments"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Cannot retrieve departments");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return new HashSet<DepartmentResponse>();

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<DepartmentResponse>>(content);
            return res;
        }

        private async Task<Guid?> CreateNewPayRun(string payRunName, PayRunForCreationRequest payRunForCreationRequest)
        {
            var body = JsonConvert.SerializeObject(payRunForCreationRequest);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunName}"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to create pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Guid>(content);
            return res;
        }

        public async Task<Guid?> CreateResidentialRecurringPayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            var res = await CreateNewPayRun("ResidentialRecurring", payRunForCreationRequest).ConfigureAwait(false);
            return res;
        }

        async Task<Guid?> ITransactionsService.CreateDirectPaymentsPayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            var res = await CreateNewPayRun("DirectPayments", payRunForCreationRequest).ConfigureAwait(false);
            return res;
        }

        async Task<Guid?> ITransactionsService.CreateHomeCarePayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            var res = await CreateNewPayRun("HomeCare", payRunForCreationRequest).ConfigureAwait(false);
            return res;
        }

        public async Task<Guid?> CreateResidentialReleaseHoldsPayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            var res = await CreateNewPayRun("ResidentialReleaseHolds", payRunForCreationRequest).ConfigureAwait(false);
            return res;
        }

        async Task<Guid?> ITransactionsService.CreateDirectPaymentsReleaseHoldsPayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            var res = await CreateNewPayRun("DirectPaymentsReleaseHolds", payRunForCreationRequest).ConfigureAwait(false);
            return res;
        }

        public async Task<PayRunDateSummaryResponse> GetDateOfLastPayRun(string payRunType)
        {
            var allowedPayRunTypes = new List<string>()
            {
                "ResidentialRecurring",
                "DirectPayments",
                "HomeCare",
                "ResidentialReleaseHolds",
                "DirectPaymentsReleaseHolds",
            };

            var correctPayRunType = allowedPayRunTypes
                .Find(p => p.Equals(payRunType, StringComparison.OrdinalIgnoreCase));
            if (correctPayRunType == null)
            {
                throw new EntityNotFoundException("The pay run type is not valid. Please check and try again");
            }

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/date-of-last-pay-run/{correctPayRunType}"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to fetch date of last pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<PayRunDateSummaryResponse>(content);
            return res;
        }

        public async Task<PagedPayRunSummaryResponse> GetPayRunSummaryList(PayRunSummaryListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"pageNumber", $"{parameters.PageNumber}"},
                {"pageSize", $"{parameters.PageSize}"},
                {"payRunId", $"{parameters.PayRunId}"},
                {"payRunTypeId", $"{parameters.PayRunTypeId}"},
                {"payRunSubTypeId", $"{parameters.PayRunSubTypeId}"},
                {"payRunStatusId", $"{parameters.PayRunStatusId}"},
                {"dateFrom", parameters.DateFrom?.DateTimeOffsetToISOString()},
                {"dateTo", parameters.DateTo?.DateTimeOffsetToISOString()},
            };
            var url = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}api/v1/pay-runs/summary-list",
                queryParams);

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Cannot retrieve pay run summary list");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<PagedPayRunSummaryResponse>(content);
            return res;
        }

        public async Task<PagedSupplierMinimalListResponse> GetUniqueSuppliersInPayRunUseCase(Guid payRunId, SupplierListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"pageNumber", $"{parameters.PageNumber}"},
                {"pageSize", $"{parameters.PageSize}"},
                {"searchTerm", $"{parameters.SearchTerm}"}
            };
            var url = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/unique-suppliers",
                queryParams);

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Cannot retrieve Suppliers in pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<PagedSupplierMinimalListResponse>(content);
            return res;
        }

        public async Task<IEnumerable<ReleasedHoldsByTypeResponse>> GetReleasedHoldsCount(DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"fromDate", $"{fromDate?.DateTimeOffsetToISOString()}"},
                {"toDate", $"{toDate?.DateTimeOffsetToISOString()}"}
            };
            var url = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}api/v1/pay-runs/released-holds-count",
                queryParams);

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Cannot retrieve released hold count");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<ReleasedHoldsByTypeResponse>>(content);
            return res;
        }

        public async Task<IEnumerable<PackageTypeResponse>> GetUniquePackageTypesInPayRunUseCase(Guid payRunId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/unique-package-types"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to retrieve package types in pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<PackageTypeResponse>>(content);
            return res;
        }

        public async Task<IEnumerable<InvoiceStatusResponse>> GetUniquePaymentStatusesInPayRunUseCase(Guid payRunId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/unique-payment-statuses"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to retrieve payment statuses in pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<InvoiceStatusResponse>>(content);
            return res;
        }

        public async Task<IEnumerable<InvoiceResponse>> GetReleasedHoldsUseCase(DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"fromDate", $"{fromDate?.DateTimeOffsetToISOString()}"},
                {"toDate", $"{toDate?.DateTimeOffsetToISOString()}"}
            };

            var url = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}api/v1/pay-runs/released-holds",
                queryParams);
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to retrieve released holds");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<InvoiceResponse>>(content);
            return res;
        }

        public async Task<PayRunDetailsResponse> GetSinglePayRunDetailsUseCase(Guid payRunId, InvoiceListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"pageNumber", $"{parameters.PageNumber}"},
                {"pageSize", $"{parameters.PageSize}"},
                {"supplierId", $"{parameters.SupplierId}"},
                {"packageTypeId", $"{parameters.PackageTypeId}"},
                {"invoiceItemPaymentStatusId", $"{parameters.InvoiceStatusId}"},
                {"searchTerm", $"{parameters.SearchTerm}"},
                {"dateFrom", $"{parameters.DateFrom?.DateTimeOffsetToISOString()}"},
                {"dateTo", $"{parameters.DateTo?.DateTimeOffsetToISOString()}"}
            };

            var url = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/details",
                queryParams);
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to retrieve pay run details");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<PayRunDetailsResponse>(content);
            return res;
        }

        public async Task<PayRunInsightsResponse> GetSinglePayRunInsightsUseCase(Guid payRunId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/summary-insights"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to retrieve pay run insights");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<PayRunInsightsResponse>(content);
            return res;
        }

        public async Task<bool> SubmitPayRunForApprovalUseCase(Guid payRunId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/status/submit-for-approval"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to submit pay run for approval");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<bool> KickBackPayRunToDraftUseCase(Guid payRunId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/status/kick-back-to-draft"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to kick pay run back to draft");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<bool> ApprovePayRunForPaymentUseCase(Guid payRunId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/status/approve-pay-run"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to approve pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<bool> ReleaseHeldInvoiceItemPaymentUseCase(ReleaseHeldInvoiceItemRequest releaseHeldInvoiceItemRequest)
        {
            var body = JsonConvert.SerializeObject(releaseHeldInvoiceItemRequest);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/release-held-invoice"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to release held invoice");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<bool> ReleaseHeldInvoiceItemPaymentListUseCase(IEnumerable<ReleaseHeldInvoiceItemRequest> releaseHeldInvoiceItemRequests)
        {
            var body = JsonConvert.SerializeObject(releaseHeldInvoiceItemRequests);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/release-held-invoice-list"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to release held invoice list");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<bool> DeleteDraftPayRunUseCase(Guid payRunId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to delete pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<DisputedInvoiceFlatResponse> HoldInvoicePaymentUseCase(Guid payRunId, Guid payRunItemId,
            DisputedInvoiceForCreationRequest disputedInvoiceForCreationRequest)
        {
            var body = JsonConvert.SerializeObject(disputedInvoiceForCreationRequest);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/pay-run-items/{payRunItemId}/hold-payment"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to hold invoice");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<DisputedInvoiceFlatResponse>(content);
            return res;
        }

        public async Task<IEnumerable<HeldInvoiceResponse>> GetHeldInvoicePaymentsUseCase()
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/invoices/held-invoice-payments"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to fetch held invoice payments");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<HeldInvoiceResponse>>(content);
            return res;
        }

        public async Task<InvoiceResponse> CreateInvoiceUseCase(InvoiceForCreationRequest invoiceForCreationRequest)
        {
            var body = JsonConvert.SerializeObject(invoiceForCreationRequest);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/invoices"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to create invoice");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<InvoiceResponse>(content);
            return res;
        }

        public async Task<IEnumerable<InvoiceStatusResponse>> GetAllInvoiceStatusesUseCase()
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/invoices/invoice-status-list"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to fetch invoice statuses");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<InvoiceStatusResponse>>(content);
            return res;
        }

        public async Task<IEnumerable<InvoiceStatusResponse>> GetInvoicePaymentStatusesUseCase()
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/invoices/invoice-payment-statuses"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to fetch invoice payment statuses");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<InvoiceStatusResponse>>(content);
            return res;
        }

        public async Task<bool> AcceptInvoiceUseCase(Guid payRunId, Guid invoiceId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/invoices/{invoiceId}/accept-invoice"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to change invoice status");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<BillResponse> CreateSupplierBillUseCase(BillCreationRequest billCreationRequest)
        {
            var body = JsonConvert.SerializeObject(billCreationRequest);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/bills"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to create supplier bill");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<BillResponse>(content);
            return res;
        }

        public async Task<bool> PaySupplierBillUseCase(IEnumerable<long> supplierBillIds)
        {
            var body = JsonConvert.SerializeObject(supplierBillIds);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/bills/pay"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to pay supplier bill");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<PagedBillSummaryResponse> GetBillSummaryList(BillSummaryListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"pageNumber", $"{parameters.PageNumber}"},
                {"pageSize", $"{parameters.PageSize}"},
                {"packageId", $"{parameters.PackageId}"},
                {"supplierId", $"{parameters.SupplierId}"},
                {"billPaymentStatusId", $"{parameters.BillPaymentStatusId}"},
                {"fromDate", parameters.FromDate?.DateTimeOffsetToISOString()},
                {"toDate", parameters.ToDate?.DateTimeOffsetToISOString()},
            };
            var url = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}api/v1/bills",
                queryParams);

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Cannot retrieve bills summary list");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<PagedBillSummaryResponse>(content);
            return res;
        }

        public async Task<PagedSupplierResponse> GetSuppliersListUseCase(SupplierListParameters parameters)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"pageNumber", $"{parameters.PageNumber}"},
                {"pageSize", $"{parameters.PageSize}"},
                {"searchTerm", $"{parameters.SearchTerm}"}
            };
            var url = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}api/v1/suppliers",
                queryParams);

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Cannot retrieve Suppliers list");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<PagedSupplierResponse>(content);
            return res;
        }

        public async Task<IEnumerable<SupplierTaxRateResponse>> GetSupplierTaxRateUseCase(long supplierId)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/suppliers/{supplierId}/tax-rates"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to retrieve supplier tax rates");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<SupplierTaxRateResponse>>(content);
            return res;
        }

        public async Task<bool> CreatePayRunHeldChatUseCase(PayRunHeldChatForCreationRequest payRunHeldChatForCreationRequest)
        {
            var body = JsonConvert.SerializeObject(payRunHeldChatForCreationRequest);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs{payRunHeldChatForCreationRequest.PayRunId}/create-held-chat"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to create held chat");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }

        public async Task<bool> AcceptInvoicesUseCase(Guid payRunId, IEnumerable<Guid> invoiceIds)
        {
            var body = JsonConvert.SerializeObject(invoiceIds);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunId}/invoices/accept-invoices"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } },
                Content = requestContent
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync("Failed to change invoice status");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return false;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<bool>(content);
            return res;
        }
    }
}
