using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PayRunInsightsResponse
    {
        public Guid PayRunId { get; set; }
        public decimal TotalInvoiceAmount { get; set; }
        public decimal TotalDifferenceFromLastCycle { get; set; }
        public int SupplierCount { get; set; }
        public int ServiceUserCount { get; set; }
        public int HoldsCount { get; set; }
        public decimal TotalHeldAmount { get; set; }
    }
}
