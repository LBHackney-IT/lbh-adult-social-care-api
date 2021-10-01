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
        private readonly IResidentRestClient _residentRestClient;

        public ResidentsService(IResidentRestClient residentRestClient)
        {
            _residentRestClient = residentRestClient;
        }

        public async Task<ServiceUserInformationResponse> GetServiceUserInformationAsync(int hackneyId)
        {
            var url = new UrlFormatter()
                .SetBaseUrl("residents")
                .AddParameter("id", hackneyId)
                .ToString();

            return await _residentRestClient
                .GetAsync<ServiceUserInformationResponse>(url, "Could not retrieve service user information");
        }
    }
}
