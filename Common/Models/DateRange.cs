using System;
using LBH.AdultSocialCare.Api.Helpers;

namespace Common.Models
{
    public class DateRange
    {
        public DateRange(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            StartDate = startDate < endDate ? startDate : endDate;
            EndDate = startDate < endDate ? endDate : startDate;
        }

        public DateTimeOffset StartDate { get; }
        public DateTimeOffset EndDate { get; }

        public decimal Weeks => Dates.WeeksBetween(StartDate, EndDate);
    }
}
