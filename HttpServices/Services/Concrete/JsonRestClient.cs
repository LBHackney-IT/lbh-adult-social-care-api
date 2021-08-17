using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using HttpServices.Models;
using HttpServices.Services.Contracts;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HttpServices.Services.Concrete
{
    /// <summary>
    /// Provides methods to communicate with REST API supporting JSON requests and responses.
    /// </summary>
    public class JsonRestClient : IRestClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public JsonRestClient(HttpClient httpClient, IOptions<TransactionApiOptions> options)
        {
            _baseUrl = options.Value.TransactionsBaseUrl.ToString();
            _apiKey = options.Value.TransactionsApiKey;

            _httpClient = httpClient;
        }

        /// <summary>
        /// Sends a GET method to specified url.
        /// </summary>
        public async Task<TResult> GetAsync<TResult>(string url, string errorMessage)
        {
            return await SubmitRequest<TResult>(url, null, errorMessage, HttpMethod.Get).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a POST method to specified url, passing a body in JSON format
        /// </summary>
        public async Task<TResult> PostAsync<TResult>(string url, object payload, string errorMessage)
        {
            return await SubmitRequest<TResult>(url, payload, errorMessage, HttpMethod.Post).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a PUT method to specified url, passing a body in JSON format
        /// </summary>
        public async Task<TResult> PutAsync<TResult>(string url, object payload, string errorMessage)
        {
            return await SubmitRequest<TResult>(url, payload, errorMessage, HttpMethod.Put).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a DELETE method to specified url
        /// </summary>
        public async Task<TResult> DeleteAsync<TResult>(string url, string errorMessage)
        {
            return await SubmitRequest<TResult>(url, null, errorMessage, HttpMethod.Delete).ConfigureAwait(false);
        }

        private async Task<TResult> SubmitRequest<TResult>(string url, object payload, string errorMessage, HttpMethod method)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri($"{_baseUrl}{url}"),
                Headers =
                {
                    {
                        HttpRequestHeader.Accept.ToString(), "application/json"
                    },
                    {
                        "x-api-key", _apiKey
                    },
                }
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
