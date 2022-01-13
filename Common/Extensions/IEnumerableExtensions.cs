using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        ///     Returns a sub-page of items in the given list, in accordance with pageNumber and pageSize parameters.
        /// </summary>
        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> list, int pageNumber, int pageSize)
        {
            return list
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
