using HttpServices.Services.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpServices.Services.Concrete
{
    public class DocumentGetClient : IDocumentGetClient
    {
        private readonly HttpClient _httpClient;
        private readonly IRestClient _restClient;

        public DocumentGetClient(HttpClient httpClient, IRestClient restClient)
        {
            _httpClient = httpClient;
            _restClient = restClient;
            _restClient.Init(httpClient);
        }

        public async Task<string> GetDocument(Guid documentId)
        {
            return await _restClient.GetAsync<string>($"documents/{documentId}", "Failed to retrieve document");
        }
    }
}
