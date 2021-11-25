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
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public ClaimCollector? ClaimCollector { get; set; }

        public string ClaimCollectorName => ClaimCollector == null ? string.Empty : ClaimCollector.GetDisplayName();

        public bool IsReclaim => ClaimCollector != null; // TODO: Remove on FE

        public string Period
        {
            get
            {
                var weeks = Math.Floor(Dates.WeeksBetween(FromDate, ToDate));
                var daysRemainder = Quantity - weeks * 7;

                return weeks == 0
                    ? $"{Quantity} days"
                    : $"{weeks} {(weeks == 1 ? "week" : "weeks")}{(daysRemainder > 0 ? $" {daysRemainder} days" : "")}";
            }
        }
    }
}
