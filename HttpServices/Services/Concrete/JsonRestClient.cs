using Common.Extensions;
using HttpServices.Services.Contracts;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpServices.Services.Concrete
{
    /// <summary>
    /// Provides methods to communicate with REST API supporting JSON requests and responses.
    /// </summary>
    public class JsonRestClient : IRestClient
    {
        private HttpClient _httpClient;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public void Init(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "HASC API");
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

        private async Task<TResult> SubmitRequest<TResult>(string url, object payload, string errorMessage,
            HttpMethod method)
        {
            Debug.Assert(_httpClient != null, "Init() method must be called before making any requests");

            // Init request message
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri($"{_httpClient.BaseAddress}{url}")
            };

            // Add request content
            if (payload != null)
            {
                var requestStream = new MemoryStream();
                var writer = new Utf8JsonWriter(requestStream);

                JsonSerializer.Serialize(writer, payload);
                requestStream.Seek(0, SeekOrigin.Begin);

                httpRequestMessage.Content = new StreamContent(requestStream); ;
            }

            using var httpResponse = await _httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                await httpResponse.ThrowResponseExceptionAsync(errorMessage).ConfigureAwait(false);
            }

            if (httpResponse.Content == null ||
                httpResponse.Content.Headers.ContentType?.MediaType != "application/json") return default;

            var responseStream = await httpResponse.Content.ReadAsStreamAsync();

            var responseContent = await JsonSerializer.DeserializeAsync<TResult>(responseStream, _options);
            return responseContent;
        }
    }
}
