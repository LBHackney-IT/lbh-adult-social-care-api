using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments
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
