using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.Tests.Extensions
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
    }
}
