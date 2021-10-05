using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.Tests.Extensions
{
    public static class Int32Extensions
    {
        public static IEnumerable<T> ItemsOf<T>(this int count, Func<T> func)
        {
            for (var i = 0; i < count; i++)
            {
                yield return func.Invoke();
            }
        }

        public static void Times(this int count, Action func)
        {
            for (var i = 0; i < count; i++)
            {
                func.Invoke();
            }
        }
    }
}
