using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
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
    }
}
