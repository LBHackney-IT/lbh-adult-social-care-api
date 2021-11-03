using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class TestRestClient
    {
        private readonly HttpClient _httpClient;

        public TestRestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Action AfterRequest { get; set; }

        public async Task<TestResponse<TContent>> GetAsync<TContent>(string url)
        {
            return await SubmitRequest<TContent>(url, null, HttpMethod.Get, CreateJsonContent);
        }

        public async Task<TestResponse<TContent>> PostAsync<TContent>(string url, object payload)
        {
            return await SubmitRequest<TContent>(url, payload, HttpMethod.Post, CreateJsonContent);
        }

        public async Task<TestResponse<TContent>> PutAsync<TContent>(string url, object payload = null)
        {
            return await SubmitRequest<TContent>(url, payload, HttpMethod.Put, CreateJsonContent);
        }

        public async Task<TestResponse<TContent>> SubmitFormAsync<TContent>(string url, object payload)
        {
            return await SubmitRequest<TContent>(url, payload, HttpMethod.Post, CreateMultipartContent);
        }

        private async Task<TestResponse<TContent>> SubmitRequest<TContent>(string url, object payload, HttpMethod method, Func<object, HttpContent> createContentFunc)
        {
            using var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url, UriKind.RelativeOrAbsolute),
                Content = createContentFunc(payload)
            };

            var response = await _httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            AfterRequest?.Invoke();

            return new TestResponse<TContent>
            {
                Message = response,
                Content = JsonConvert.DeserializeObject<TContent>(json)
            };
        }

        private static HttpContent CreateJsonContent(object payload)
        {
            if (payload is null) return null;

            var jsonBody = JsonConvert.SerializeObject(payload);
            return new StringContent(jsonBody, Encoding.UTF8, "application/json");
        }

#pragma warning disable CA2000
        private static HttpContent CreateMultipartContent(object payload)
        {
            var multipartContent = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            var properties = payload.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                if (property.PropertyType.IsAssignableFrom(typeof(IFormFile)))
                {
                    var file = (IFormFile) property.GetValue(payload);
                    if (file == null) continue;

                    var memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);

                    multipartContent.Add(new StreamContent(memoryStream), property.Name, property.Name);
                }
                else
                {
                    multipartContent.Add(new StringContent(property.GetValue(payload)?.ToString()), property.Name);
                }
            }

            return multipartContent;
        }
    }
#pragma warning restore CA2000

    public class TestResponse<TContent>
    {
        public HttpResponseMessage Message { get; set; }

        public TContent Content { get; set; }
    }
}
