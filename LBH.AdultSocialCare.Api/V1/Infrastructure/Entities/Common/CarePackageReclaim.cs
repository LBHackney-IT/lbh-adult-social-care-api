using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    public class CarePackageReclaim : BaseEntity
    {
        public CarePackageReclaim()
        {
            Elements = new List<CarePackageReclaimElement>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        public int ClaimCollectorId { get; set; }

        public int SupplierId { get; set; }

        public int StatusId { get; set; }                   // TODO: VK: Seed ReclaimStatuses

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }

        public string AssessmentFileUrl { get; set; }

        [ForeignKey(nameof(ClaimCollectorId))]
        public PackageCostClaimer ClaimCollector { get; set; } // TODO: VK: Rename PackageCostClaimer to ClaimCollector?

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(StatusId))]
        public ReclaimStatus Status { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }

        public virtual ICollection<CarePackageReclaimElement> Elements { get; set; }
    }
}
