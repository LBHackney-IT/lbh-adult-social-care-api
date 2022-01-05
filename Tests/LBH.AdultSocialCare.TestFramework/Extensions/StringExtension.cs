using System;
using System.Globalization;

namespace LBH.AdultSocialCare.TestFramework.Extensions
{
    public static class StringExtension
    {
        public static DateTimeOffset ToUtcDate(this string date)
        {
            return DateTimeOffset.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
