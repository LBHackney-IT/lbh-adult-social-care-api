using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="int"/>.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Returns true if the given value exists in the list, otherwise false.
        /// </summary>
        public static bool In(this int value, params int[] list)
        {
            return list.Contains(value);
        }

        /// <summary>
        /// Returns true if the given value doesn't exists in the list, otherwise false.
        /// </summary>
        public static bool NotIn(this int value, params int[] list)
        {
            return !value.In(list);
        }
    }
}
