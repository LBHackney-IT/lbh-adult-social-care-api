using Common.Extensions.Concrete;
using System;

namespace Common.Extensions
{
    public static class DateExtensions
    {
        public static string DateTimeToISOString(this DateTime dateTime)
        {
            var dateString = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFF") + "Z";

            return dateString;
        }

        public static string DateTimeOffsetToISOString(this DateTimeOffset dateTimeOffset)
        {
            var dateString = dateTimeOffset.ToString("yyyy-MM-ddTHH:mm:ss.FFF") + "Z";

            return dateString;
        }

        public static bool IsInRange(this DateTimeOffset dateToCheck, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return new DateTimeOffsetRange(startDate, endDate).Includes(dateToCheck);
        }

        public static bool DatesInRange(DateTimeOffset rangeFrom, DateTimeOffset rangeTo, DateTimeOffset dateOne, DateTimeOffset dateTwo)
        {
            return dateOne.IsInRange(rangeFrom, rangeTo) &&
                   dateTwo.IsInRange(rangeFrom, rangeTo);
        }
    }
}
