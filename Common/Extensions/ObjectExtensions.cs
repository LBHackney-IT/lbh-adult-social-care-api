using Common.Exceptions.CustomExceptions;
using System;
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

    public static class Ensure
    {
        public static async Task<T> ExistsAsync<T>(Func<Task<T>> action, string message = "Entity not found")
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            var entity = await action.Invoke();

            if (entity is null)
            {
                throw new ApiException(message, HttpStatusCode.NotFound);
            }

            return entity;
        }

        public static T Exists<T>(Func<T> action, string message = "Entity not found")
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            var entity = action.Invoke();

            if (entity is null)
            {
                throw new ApiException(message, HttpStatusCode.NotFound);
            }

            return entity;
        }
    }
}
