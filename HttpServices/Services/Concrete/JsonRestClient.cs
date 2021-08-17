using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using HttpServices.Services.Contracts;
using Newtonsoft.Json;

namespace HttpServices.Services.Concrete
{
    /// <summary>
    /// Provides methods to communicate with REST API supporting JSON requests and responses.
    /// </summary>
    public class JsonRestClient : IRestClient
    {
        private readonly HttpClient _httpClient;

        public JsonRestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Sends a GET method to specified url.
        /// </summary>
        public async Task<TResult> Get<TResult>(string url, string errorMessage, string apiKey = "") where TResult : class
        {
            return await SubmitRequest<TResult>(url, null, errorMessage, HttpMethod.Get, apiKey).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a POST method to specified url, passing a body in JSON format
        /// </summary>
        public async Task<TResult> Post<TResult>(string url, object payload, string errorMessage, string apiKey = "") where TResult : class
        {
            return await SubmitRequest<TResult>(url, payload, errorMessage, HttpMethod.Post, apiKey).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a PUT method to specified url, passing a body in JSON format
        /// </summary>
        public async Task<TResult> Put<TResult>(string url, object payload, string errorMessage, string apiKey = "") where TResult : class
        {
            return await SubmitRequest<TResult>(url, payload, errorMessage, HttpMethod.Put, apiKey).ConfigureAwait(false);
        }

        private async Task<TResult> SubmitRequest<TResult>(string url, object payload, string errorMessage, HttpMethod method, string apiKey = "") where TResult : class
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url),
                Headers =
                {
                    {
                        HttpRequestHeader.Accept.ToString(), "application/json"
                    },
                    {
                        "x-api-key", apiKey
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
                httpResponse.Content.Headers.ContentType?.MediaType != "application/json") return null;

            var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TResult>(content);
        }
    }
}
