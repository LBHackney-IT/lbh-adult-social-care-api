using System.Collections.Generic;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IEnumerableExtensions
    {
        public static List<T> GetPage<T>(this IEnumerable<T> list, int pageNumber, int pageSize)
        {
            return list
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
