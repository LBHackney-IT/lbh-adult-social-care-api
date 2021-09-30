using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HttpServices.Helpers;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;

namespace HttpServices.Services.Concrete
{
    public class ResidentsService : IResidentsService
    {
        private readonly IRestClient _restClient;

        public ResidentsService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ServiceUserInformationResponse> GetAsync(int residentsId)
        {
            var url = new UrlFormatter()
                .SetBaseUrl("residents")
                .AddParameter("id", residentsId)
                .ToString();

            return await _restClient
                .GetAsync<ServiceUserInformationResponse>(url, "Could not retrieve service user information");
        }
    }
}
