using System;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
{
    public class PayrunInvoice : BaseEntity
    {
        public Guid PayrunId { get; set; }
        public Guid InvoiceId { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public Payrun Payrun { get; set; }
        public Invoice Invoice { get; set; }
    }
}
