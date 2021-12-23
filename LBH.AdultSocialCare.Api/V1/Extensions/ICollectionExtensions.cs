using System.Collections.Generic;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class ICollectionExtensions
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }

            return collection;
        }

        public static ICollection<T> AddRange<T>(this ICollection<T> collection, params T[] items)
        {
            collection.AddRange(items.AsEnumerable());
            return collection;
        }
    }
}
