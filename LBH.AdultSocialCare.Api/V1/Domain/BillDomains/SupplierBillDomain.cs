using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.BillDomains
{
    public class SupplierBillDomain
    {
        public string SupplierName { get; set; }
        public string BillTitle { get; set; }
        public List<SupplierBillItemDomain> SupplierBillItem { get; set; }

    }
}
