using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
                throw new Exception("Cannot retrieve departments");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return new HashSet<DepartmentResponse>();

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<DepartmentResponse>>(content);
            return res;
        }

        private async Task<Guid?> CreateNewPayRun(string payRunName)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_httpClient.BaseAddress}api/v1/pay-runs/{payRunName}"),
                Headers = { { HttpRequestHeader.Accept.ToString(), "application/json" } }
            };

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Failed to create pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Guid>(content);
            return res;
        }

        public async Task<Guid?> CreateResidentialRecurringPayRun()
        {
            var res = await CreateNewPayRun("ResidentialRecurring").ConfigureAwait(false);
            return res;
        }

        async Task<Guid?> ITransactionsService.CreateDirectPaymentsPayRun()
        {
            var res = await CreateNewPayRun("DirectPayments").ConfigureAwait(false);
            return res;
        }

        async Task<Guid?> ITransactionsService.CreateHomeCarePayRun()
        {
            var res = await CreateNewPayRun("HomeCare").ConfigureAwait(false);
            return res;
        }

        public async Task<Guid?> CreateResidentialReleaseHoldsPayRun()
        {
            var res = await CreateNewPayRun("ResidentialReleaseHolds").ConfigureAwait(false);
            return res;
        }

        async Task<Guid?> ITransactionsService.CreateDirectPaymentsReleaseHoldsPayRun()
        {
            var res = await CreateNewPayRun("DirectPaymentsReleaseHolds").ConfigureAwait(false);
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
                throw new Exception("Cannot retrieve pay run summary list");
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
                throw new Exception("Cannot retrieve Suppliers in pay run");
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
                {"fromDate", $"{fromDate}"},
                {"toDate", $"{toDate}"}
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
                throw new Exception("Cannot retrieve released hold count");
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
                throw new Exception("Failed to retrieve package types in pay run");
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
                throw new Exception("Failed to retrieve payment statuses in pay run");
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<InvoiceStatusResponse>>(content);
            return res;
        }
    }
}
