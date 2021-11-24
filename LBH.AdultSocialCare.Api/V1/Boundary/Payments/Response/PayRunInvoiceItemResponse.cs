using System;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PayRunInvoiceItemResponse
    {
        public Guid Id { get; set; } // Invoice item id
        public string Name { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public ClaimCollector? ClaimCollector { get; set; }

        public string ClaimCollectorName => ClaimCollector == null ? string.Empty : ClaimCollector.GetDisplayName();

        public int Days => (ToDate - FromDate).Days;
        public bool IsReclaim => ClaimCollector != null; // TODO: Remove on FE

        public string Period
        {
            get
            {
                var weeks = Math.Floor(Dates.WeeksBetween(FromDate, ToDate));
                var daysRemainder = Days - weeks * 7;

                return weeks == 0
                    ? $"{Days} days"
                    : $"{weeks} {(weeks == 1 ? "week" : "weeks")}{(daysRemainder > 0 ? $" {daysRemainder} days" : "")}";
            }
        }
    }
}
