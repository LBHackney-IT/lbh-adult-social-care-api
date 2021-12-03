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

        // ensure that end date is included in paid interval
        public decimal WeeksInclusive => Dates.WeeksBetween(StartDate, EndDate.AddDays(1));
    }
}
