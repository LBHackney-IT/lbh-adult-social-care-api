using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public static class Dates
    {
        public static DateTimeOffset Max(params DateTimeOffset?[] dates)
        {
            var maxDate = dates
                .Where(date => date.HasValue)
                .Max();

            return maxDate ?? throw new InvalidOperationException("Dates input parameter doesn't contain any valid date");
        }

        public static DateTimeOffset Min(params DateTimeOffset?[] dates)
        {
            var minDate = dates
                .Where(date => date.HasValue)
                .Min();

            return minDate ?? throw new InvalidOperationException("Dates input parameter doesn't contain any valid date");
        }

        public static decimal WeeksBetween(DateTimeOffset date1, DateTimeOffset date2)
        {
            return (date2.Date - date1.Date).Days / 7M;
        }
    }
}
