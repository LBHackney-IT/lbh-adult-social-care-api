using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpServices.Services.Contracts
{
    public interface IResidentRestClient : IRestClient
    {
        /// <summary>
        /// Sends a GET request to specified url
        /// </summary>
        Task<TResult> GetAsync<TResult>(string url, string errorMessage);
    }
}
