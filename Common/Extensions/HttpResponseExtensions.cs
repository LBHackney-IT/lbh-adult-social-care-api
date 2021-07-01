using Common.Exceptions.CustomExceptions;
using Common.Exceptions.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task ThrowResponseExceptionAsync(this HttpResponseMessage httpResponse, string defaultErrorMessage)
        {
            var err = JsonConvert.DeserializeObject<ApiError>(await httpResponse.Content.ReadAsStringAsync());
            if (string.IsNullOrEmpty(err?.Message))
            {
                throw new ApiException(defaultErrorMessage, (int) httpResponse.StatusCode);
            }
            throw new ApiException(err?.Message, (int) httpResponse.StatusCode, err?.Errors, err?.Detail);
        }
    }
}
