using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class CedarFileInvoiceHeader
    {
        public int InvoiceHeaderId { get; set; }
        public int InvoiceNumber { get; set; }
        public int Subtype { get; set; }
        public int? InvoiceSupplierNumber { get; set; }
        public string InvoiceReferenceNumber { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public DateTimeOffset ReceivedDate { get; set; }
        public string SupplierSiteReferenceId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal GrossVatAmount { get; set; }
        public List<CedarFileInvoiceLineDomain> InvoiceItems { get; set; }
    }
}
