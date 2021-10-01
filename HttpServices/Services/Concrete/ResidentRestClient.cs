using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using HttpServices.Services.Contracts;
using Newtonsoft.Json;

namespace HttpServices.Services.Concrete
{
    //TODO FK: temp solution for to avoid two rest client crashed
    public class ResidentRestClient : JsonRestClient, IResidentRestClient
    {
        private readonly HttpClient _httpClient;

        public ResidentRestClient(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Sends a GET method to specified url.
        /// </summary>
        public async Task<TResult> GetAsync<TResult>(string url, string errorMessage)
        {
            return await SubmitRequest<TResult>(url, null, errorMessage, HttpMethod.Get).ConfigureAwait(false);
        }

        private async Task<TResult> SubmitRequest<TResult>(string url, object payload, string errorMessage, HttpMethod method)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri($"{_httpClient.BaseAddress}{url}")
            };

            if (payload != null)
            {
                var jsonBody = JsonConvert.SerializeObject(payload);
                httpRequestMessage.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            var httpResponse = await _httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync(errorMessage).ConfigureAwait(false);
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType?.MediaType != "application/json") return default;

            var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TResult>(content);
        }
    }
}
