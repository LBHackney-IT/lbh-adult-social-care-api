using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
{
    public class InvoiceItem : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }
        public Guid PackageId { get; set; }

        public decimal WeeklyCost { get; set; }
        public decimal TotalCost { get; set; }

        public int Quantity { get; set; }

        public InvoiceStatus Status { get; set; }
        public PriceEffect PriceEffect { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice { get; set; }
    }
}