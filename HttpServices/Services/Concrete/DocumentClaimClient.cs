using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<DocumentClaimResponse> CreateClaimAndDocument(DocumentClaimRequest request)
        {
            return await _restClient.PostAsync<DocumentClaimResponse>("claims/claim_and_document", request, "Failed to create document claim");
        }
    }
}
