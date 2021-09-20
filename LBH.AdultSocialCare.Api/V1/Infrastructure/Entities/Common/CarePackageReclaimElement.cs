using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    public class CarePackageReclaimElement : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageReclaimId { get; set; }

        public Guid CarePackageId { get; set; }

        public int PackageTypeId { get; set; }

        public int StatusId { get; set; }

        public int TypeId { get; set; }

        public int ClaimCollectorId { get; set; }

        public string ClaimReason { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(13, 2)")]
        public decimal Amount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        [ForeignKey(nameof(StatusId))]
        public CareChargeStatus Status { get; set; }

        [ForeignKey(nameof(TypeId))]
        public CareChargeType Type { get; set; }

        [ForeignKey(nameof(ClaimCollectorId))]
        public PackageCostClaimer ClaimCollector { get; set; }

        public CarePackageReclaim Reclaim { get; set; }
    }
}
