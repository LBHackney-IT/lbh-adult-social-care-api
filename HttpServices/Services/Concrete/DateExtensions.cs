using System;

namespace HttpServices.Services.Concrete
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
    }
}
