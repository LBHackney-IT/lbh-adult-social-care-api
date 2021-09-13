using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge
{
    public class InvoiceCreditNote : BaseEntity
    {
        [Key] public Guid InvoiceCreditNoteId { get; set; }
        public int SupplierId { get; set; }
        public Guid ServiceUserId { get; set; }
        public bool SentOrInvoiced { get; set; } // This note has been included in an invoice or sent to supplier if they charge service user directly
        public bool HasBeenAddedToUserInvoice { get; set; } // In cases where hackney sends invoices to users asking for their contribution
        public int PackageTypeId { get; set; } // residential, nursing, etc.
        public Guid PackageId { get; set; }
        public int ChargeTypeId { get; set; } // overcharge, undercharge
        [Required] public string Description { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal Amount { get; set; }
        public int PriceEffectId { get; set; } // none, add, subtract
        public Guid? CareChargeElementId { get; set; } // possible source of a credit note
        public int ClaimCollectorId { get; set; }

        [ForeignKey(nameof(SupplierId))] public Supplier Supplier { get; set; }
        [ForeignKey(nameof(ServiceUserId))] public Client ServiceUser { get; set; }
        [ForeignKey(nameof(PackageTypeId))] public Package Package { get; set; }
        [ForeignKey(nameof(PriceEffectId))] public InvoiceItemPriceEffect PriceEffect { get; set; }
        [ForeignKey(nameof(ChargeTypeId))] public InvoiceNoteChargeType ChargeType { get; set; }
        [ForeignKey(nameof(CareChargeElementId))] public CareChargeElement CareChargeElement { get; set; }
        [ForeignKey(nameof(ClaimCollectorId))] public PackageCostClaimer ClaimCollector { get; set; }
    }
}
