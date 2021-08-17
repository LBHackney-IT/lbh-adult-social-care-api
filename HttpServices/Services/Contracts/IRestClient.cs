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
        Task<TResult> Get<TResult>(string url, string errorMessage, string apiKey = "") where TResult : class;

        /// <summary>
        /// Sends a POST method to specified url
        /// </summary>
        Task<TResult> Post<TResult>(string url, object payload, string errorMessage, string apiKey = "") where TResult : class;

        /// <summary>
        /// Sends a PUT request to specified url.
        /// </summary>
        Task<TResult> Put<TResult>(string url, object payload, string errorMessage, string apiKey = "") where TResult : class;
    }
}
