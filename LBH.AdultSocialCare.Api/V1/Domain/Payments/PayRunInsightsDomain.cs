namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class PayRunInsightsDomain
    {
        public decimal TotalInvoiceAmount { get; set; }
        public int SupplierCount { get; set; }
        public int ServiceUserCount { get; set; }
        public int HoldsCount { get; set; }
        public decimal TotalHeldAmount { get; set; }
        public bool IsCedarFileDownloaded { get; set; }
    }
}
