using HttpServices.Helpers;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpServices.Services.Concrete
{
    public class ResidentsService : IResidentsService
    {
        private readonly IRestClient _restClient;

        public ResidentsService(HttpClient httpClient, IRestClient restClient)
        {
            _restClient = restClient;
            restClient.Init(httpClient);
        }

        public async Task<ServiceUserInformationResponse> GetServiceUserInformationAsync(int hackneyId)
        {
            var url = new UrlFormatter()
                .SetBaseUrl("residents")
                .AddParameter("mosaic_id", hackneyId)
                .ToString();

            return await _restClient
                .GetAsync<ServiceUserInformationResponse>(url, "Could not retrieve service user information");
        }

        public async Task<ServiceUserInformationResponse> SearchServiceUserInformationAsync(ServiceUserQueryRequest request)
        {
            var url = new UrlFormatter()
                .SetBaseUrl("residents")
                .AddParameter("mosaic_id", request.HackneyId)
                .AddParameter("first_name", request.FirstName)
                .AddParameter("last_name", request.LastName)
                .AddParameter("postCode", request.PostCode)
                .AddParameter("date_of_birth", request.DateOfBirth)
                .AddParameter("cursor", request.Cursor ?? 0)
                .ToString();

            return await _restClient
                .GetAsync<ServiceUserInformationResponse>(url, "Could not retrieve service user information");
        }
    }
}
