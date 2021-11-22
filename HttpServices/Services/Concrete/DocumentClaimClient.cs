using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;

namespace HttpServices.Services.Concrete
{
    public class DocumentClaimClient : IDocumentClaimClient
    {
        private readonly HttpClient _httpClient;
        private readonly IRestClient _restClient;

        public DocumentClaimClient(HttpClient httpClient, IRestClient restClient)
        {
            _httpClient = httpClient;
            _restClient = restClient;
            _restClient.Init(httpClient);
        }

        public async Task<DocumentClaimResponse> CreateClaim(DocumentClaimRequest request)
        {
            return await _restClient.PostAsync<DocumentClaimResponse>("claims", request, "Failed to create document claim");
        }
    }
}