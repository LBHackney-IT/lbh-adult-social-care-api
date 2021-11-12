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

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
