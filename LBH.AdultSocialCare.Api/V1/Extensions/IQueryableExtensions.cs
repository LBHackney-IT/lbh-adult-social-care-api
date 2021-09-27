using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Returns a sub-page of items in the given list, in accordance with pageNumber and pageSize parameters.
        /// </summary>
        public static IQueryable<T> GetPage<T>(this IQueryable<T> list, int pageNumber, int pageSize)
        {
            return list
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public static IQueryable<T> TrackChanges<T>(this IQueryable<T> list, bool trackChanges) where T : class
        {
            if (trackChanges)
            {
                return list;
            }
            return list
                .AsNoTracking();
        }
    }
}
