using System;

namespace LBH.AdultSocialCare.Functions.Payruns.Domain
{
    public class RefundInfo
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public decimal CurrentCost { get; set; }
        public decimal RefundAmount { get; set; }
        public decimal Quantity { get; set; }

        public bool NetCostsCompensated { get; set; }

        public bool IsEmpty { get; private set; }

        public static RefundInfo Empty => new RefundInfo { IsEmpty = true };
    }
}
