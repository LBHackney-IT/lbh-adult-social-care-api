using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.InvoiceBoundary.Response
{
    public class InvoiceItemResponse
    {
        public string ItemName { get; set; }
        public decimal? PricePerUnit { get; set; }
        public int? Quantity { get; set; }
        public Guid? SupplierReturnItemId { get; set; }
        public Guid? CreatorId { get; set; }
    }
}
