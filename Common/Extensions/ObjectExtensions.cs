using Common.Exceptions.CustomExceptions;
using System.Net;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class ObjectExtensions
    {
        public static T EnsureExists<T>(this T obj, string errorMessage = "Entity not found")
        {
            if (obj is null)
            {
                throw new ApiException(errorMessage, HttpStatusCode.NotFound);
            }

            return obj;
        }

        public static Task<T> EnsureExistsAsync<T>(this Task<T> obj, string errorMessage = "Entity not found")
        {
            if (obj.Result is null)
            {
                throw new ApiException(errorMessage, HttpStatusCode.NotFound);
            }

            return obj;
        }
    }
}
