using System;

namespace LBH.AdultSocialCare.Functions.Payruns.Domain
{
    public class Refund
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
