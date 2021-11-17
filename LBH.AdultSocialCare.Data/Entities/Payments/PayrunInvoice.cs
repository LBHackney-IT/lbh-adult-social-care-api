using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Data.Entities.Payments
{
    public class PayrunInvoice : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PayrunId { get; set; }
        public Guid InvoiceId { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public Payrun Payrun { get; set; }
        public Invoice Invoice { get; set; }
    }
}
