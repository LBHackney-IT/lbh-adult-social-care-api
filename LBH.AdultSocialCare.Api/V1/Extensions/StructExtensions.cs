using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="int"/>.
    /// </summary>
    public static class StructExtensions
    {
        /// <summary>
        /// Returns true if the given value exists in the list, otherwise false.
        /// </summary>
        public static bool In<T>(this T value, params T[] list) where T : struct
        {
            return list.Contains(value);
        }

        /// <summary>
        /// Returns true if the given value doesn't exists in the list, otherwise false.
        /// </summary>
        public static bool NotIn<T>(this T value, params T[] list) where T : struct
        {
            return !value.In(list);
        }
    }
}
