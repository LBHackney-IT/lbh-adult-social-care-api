using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class SupplierBillResponse
    {
        public string SupplierName { get; set; }
        public string BillTitle { get; set; }
        public IEnumerable<SupplierBillItemResponse> SupplierBillItem { get; set; }
    }
}
