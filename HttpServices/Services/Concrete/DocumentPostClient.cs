using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;

namespace HttpServices.Services.Concrete
{
    public class DocumentPostClient : IDocumentPostClient
    {
        private readonly HttpClient _httpClient;        
        private readonly IRestClient _restClient;

        public DocumentPostClient(HttpClient httpClient, IRestClient restClient)
        {
            _httpClient = httpClient;
            _restClient = restClient;
            _restClient.Init(httpClient);
        }

        public async Task<string> CreateDocument(Guid documentId, DocumentUploadRequest request)
        {
           return await _restClient.PostAsync<string>($"documents/{documentId}", request, "Failed to create document");
        }
    }
}
