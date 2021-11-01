using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.Tests.Extensions
{
    public static class Int32Extensions
    {
        public static List<T> ItemsOf<T>(this int count, Func<T> func)
        {
            var result = new List<T>();

            for (var i = 0; i < count; i++)
            {
                result.Add(func.Invoke());
            }

            return result;
        }

        public static void Times(this int count, Action<int> func)
        {
            for (var i = 0; i < count; i++)
            {
                func.Invoke(i);
            }
        }
    }
}
