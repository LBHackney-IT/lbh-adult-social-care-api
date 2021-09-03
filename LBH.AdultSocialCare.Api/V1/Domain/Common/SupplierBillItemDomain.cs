namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SupplierBillItemDomain
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public string CostCentre { get; set; }
        public float TaxRatePercentage { get; set; }
    }
}
