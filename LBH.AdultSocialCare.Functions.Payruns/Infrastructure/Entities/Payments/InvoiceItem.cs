using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments
{
    public class InvoiceItem : BaseEntity
    {
        public InvoiceItem()
        {
            IsReclaim = false;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid InvoiceId { get; set; }
        public Guid PackageId { get; set; }

        public decimal WeeklyCost { get; set; }
        public decimal TotalCost { get; set; }

        public decimal Quantity { get; set; }

        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public bool? IsReclaim { get; set; }

        public ClaimCollector ClaimCollector { get; set; }
        public PriceEffect PriceEffect { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice { get; set; }
    }
}
