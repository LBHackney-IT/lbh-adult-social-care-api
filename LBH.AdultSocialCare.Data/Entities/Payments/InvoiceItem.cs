using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Data.Entities.Payments
{
    public class InvoiceItem : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid InvoiceId { get; set; }
        public Guid? CarePackageDetailId { get; set; }
        public Guid? CarePackageReclaimId { get; set; }

        public decimal WeeklyCost { get; set; }
        public decimal TotalCost { get; set; }

        public decimal Quantity { get; set; }

        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }

        public ClaimCollector? ClaimCollector { get; set; }
        public PriceEffect PriceEffect { get; set; }

        public long SourceVersion { get; set; }
        public bool NetCostsCompensated { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice { get; set; }

        [ForeignKey(nameof(CarePackageDetailId))]
        public CarePackageDetail CarePackageDetail { get; set; }

        [ForeignKey(nameof(CarePackageReclaimId))]
        public CarePackageReclaim CarePackageReclaim { get; set; }
    }
}
