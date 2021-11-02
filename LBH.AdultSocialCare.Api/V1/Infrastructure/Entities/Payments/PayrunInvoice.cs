using System;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
{
    public class PayrunInvoice
    {
        public Guid PayrunId { get; set; }
        public Guid InvoiceId { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public Payrun Payrun { get; set; }
        public Invoice Invoice { get; set; }
    }
}
