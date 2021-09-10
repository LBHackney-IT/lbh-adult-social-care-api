using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class InvoiceCreditNotePlainDomain
    {
        public Guid InvoiceCreditNoteId { get; set; }
        public int SupplierId { get; set; }
        public Guid ServiceUserId { get; set; }
        public bool SentOrInvoiced { get; set; }
        public bool HasBeenAddedToUserInvoice { get; set; }
        public int PackageTypeId { get; set; }
        public Guid PackageId { get; set; }
        public int ChargeTypeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int PriceEffectId { get; set; }
        public Guid? CareChargeElementId { get; set; }
        public int ClaimCollectorId { get; set; }
    }
}
