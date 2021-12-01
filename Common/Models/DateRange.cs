using System;

namespace Common.Models
{
    public class DateRange
    {
        public DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate < endDate ? startDate : endDate;
            EndDate = startDate < endDate ? endDate : startDate;
        }

        public DateTimeOffset StartDate { get; }
        public DateTimeOffset EndDate { get; }
    }
}
