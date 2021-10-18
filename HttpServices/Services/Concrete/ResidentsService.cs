using System.Net.Http;
using System.Threading.Tasks;
using HttpServices.Helpers;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;

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
                .AddParameter("id", hackneyId)
                .ToString();

            return await _restClient
                .GetAsync<ServiceUserInformationResponse>(url, "Could not retrieve service user information");
        }

        public async Task<ServiceUserInformationResponse> SearchServiceUserInformationAsync(ServiceUserQueryRequest request)
        {
            var url = new UrlFormatter()
                .SetBaseUrl("residents")
                .AddParameter("id", request.HackneyId)
                .AddParameter("firstName", request.FirstName)
                .AddParameter("lastName", request.LastName)
                .AddParameter("postCode", request.PostCode)
                .AddParameter("dateOfBirth", request.DateOfBirth)
                .ToString();

            return await _restClient
                .GetAsync<ServiceUserInformationResponse>(url, "Could not retrieve service user information");
        }
    }
}
