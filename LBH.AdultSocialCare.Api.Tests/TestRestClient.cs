using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class TestRestClient
    {
        private readonly HttpClient _httpClient;

        public TestRestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TestResponse<TContent>> GetAsync<TContent>(string url)
        {
            return await SubmitRequest<TContent>(url, null, HttpMethod.Get).ConfigureAwait(false);
        }

        public async Task<TestResponse<TContent>> PostAsync<TContent>(string url, object payload)
        {
            return await SubmitRequest<TContent>(url, payload, HttpMethod.Post).ConfigureAwait(false);
        }

        private async Task<TestResponse<TContent>> SubmitRequest<TContent>(string url, object payload, HttpMethod method)
        {
            using var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url, UriKind.RelativeOrAbsolute)
            };

            if (payload != null)
            {
                var jsonBody = JsonConvert.SerializeObject(payload);
                httpRequestMessage.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return new TestResponse<TContent>()
            {
                Message = response,
                Content = JsonConvert.DeserializeObject<TContent>(json)
            };
        }
    }

    public class TestResponse<TContent>
    {
        public HttpResponseMessage Message { get; set; }

        public TContent Content { get; set; }
    }
}
