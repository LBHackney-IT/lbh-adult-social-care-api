using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.BillDomains
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
