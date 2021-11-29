using System;

namespace LBH.AdultSocialCare.Functions.Payruns.Domain
{
    public class RefundInfo
    {
        public DateTimeOffset PreviousStartDate { get; set; }
        public DateTimeOffset PreviousEndDate { get; set; }

        public DateTimeOffset CurrentStartDate { get; set; }
        public DateTimeOffset CurrentEndDate { get; set; }

        public decimal CurrentCost { get; set; }
        public decimal RefundAmount { get; set; }
        public decimal Quantity { get; set; }

        public bool NetCostsCompensated { get; set; }

        public bool IsEmpty { get; private set; }

        public static RefundInfo Empty => new RefundInfo { IsEmpty = true };
    }
}
