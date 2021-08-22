using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SupplierBillDomain
    {
        public string SupplierName { get; set; }
        public string BillTitle { get; set; }
        public List<SupplierBillItemDomain> SupplierBillItem { get; set; }

    }
}
