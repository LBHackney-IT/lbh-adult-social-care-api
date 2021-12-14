using System;

namespace LBH.AdultSocialCare.Functions.Payruns.Tests.Extensions
{
    public static class StringExtension
    {
        public static DateTimeOffset ToUtcDate(this string date)
        {
            return DateTimeOffset.Parse($"{date}T00:00:00.000Z");
        }
    }
}
