using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
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
