using System;
using Common.Extensions;
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
        public decimal TotalCost { get; set; }
        public ClaimCollector? ClaimCollector { get; set; }

        public string ClaimCollectorName => ClaimCollector == null ? string.Empty : ClaimCollector.GetDisplayName();

        public bool IsReclaim => ClaimCollector != null; // TODO: Remove on FE

        // end date is inclusive thus + 1 day
        public int Quantity => (ToDate - FromDate).Days + 1;

        public string Period
        {
            get
            {
                var weeks = Math.DivRem(Quantity, 7, out var daysRemainder);

                return weeks == 0
                    ? Pluralize(daysRemainder, "day")
                    : $"{Pluralize(weeks, "week")} {Pluralize(daysRemainder, "day")}";
            }
        }

        private static string Pluralize(int number, string term)
        {
            if (number == 0) return String.Empty;

            return number == 1
                ? $"{number} {term}"
                : $"{number} {term}s";
        }
    }
}
