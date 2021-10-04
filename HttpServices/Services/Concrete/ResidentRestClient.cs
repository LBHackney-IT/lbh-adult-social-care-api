using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using HttpServices.Services.Contracts;
using Newtonsoft.Json;

namespace HttpServices.Services.Concrete
{
    //TODO FK: temp solution for to avoid two rest client crashed
    public class ResidentRestClient : JsonRestClient, IResidentRestClient
    {
        private readonly HttpClient _httpClient;

        public ResidentRestClient(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
