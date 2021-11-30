using System;
using LBH.AdultSocialCare.Api.Helpers;

namespace LBH.AdultSocialCare.Functions.Payruns.Domain
{
    public class DateRange
    {
        public DateRange(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTimeOffset StartDate { get; }
        public DateTimeOffset EndDate { get; }

        public decimal Weeks => Dates.WeeksBetween(StartDate, EndDate);
    }
}
