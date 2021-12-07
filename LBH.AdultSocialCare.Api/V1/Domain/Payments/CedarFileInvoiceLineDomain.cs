using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class CedarFileInvoiceLineDomain
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceNumber { get; set; }
        public int InvoiceLineNumber { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public int TaxFlag { get; set; }
        public string CostCentre { get; set; }
        public string Subjective { get; set; }
        public string Analysis { get; set; }
        public string TaxStatus { get; set; }
    }
}
