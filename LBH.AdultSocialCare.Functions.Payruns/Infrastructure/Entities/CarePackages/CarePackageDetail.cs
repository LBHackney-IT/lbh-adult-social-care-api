using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.CarePackages
{
    public class CarePackageDetail : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public PackageDetailType Type { get; set; }

        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        public PaymentPeriod CostPeriod { get; set; }
        public PaymentPeriod ServicePeriod { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string UnitOfMeasure { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }
    }
}
