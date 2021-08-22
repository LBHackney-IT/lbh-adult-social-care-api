using System.Threading.Tasks;

namespace HttpServices.Services.Contracts
{
    /// <summary>
    /// Provides methods to communicate with REST API
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Sends a GET request to specified url
        /// </summary>
        Task<TResult> GetAsync<TResult>(string url, string errorMessage);

        /// <summary>
        /// Sends a POST method with payload in request body to specified url
        /// </summary>
        Task<TResult> PostAsync<TResult>(string url, object payload, string errorMessage);

        /// <summary>
        /// Sends a PUT request with payload in request body  to specified url.
        /// </summary>
        Task<TResult> PutAsync<TResult>(string url, object payload, string errorMessage);

        /// <summary>
        /// Sends a DELETE request to specified url.
        /// </summary>
        Task<TResult> DeleteAsync<TResult>(string url, string errorMessage);
    }
}
