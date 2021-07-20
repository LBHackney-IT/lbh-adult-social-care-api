using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.SupplierBillBoundary.Response
{
    public class SupplierBillResponse
    {
        public string SupplierName { get; set; }
        public string BillTitle { get; set; }
        public IEnumerable<SupplierBillItemResponse> SupplierBillItem { get; set; }
    }
}
