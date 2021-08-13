using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.InvoiceDomains
{
    public class InvoiceItemDomain
    {
        public string ItemName { get; set; }
        public decimal? PricePerUnit { get; set; }
        public int? Quantity { get; set; }
        public Guid? SupplierReturnItemId { get; set; }
        public Guid? CreatorId { get; set; }
    }
}
