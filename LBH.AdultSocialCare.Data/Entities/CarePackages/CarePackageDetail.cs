using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Data.Entities.CarePackages
{
    public class CarePackageDetail : BaseVersionedEntity, IPackageItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public PackageDetailType Type { get; set; }

        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        public PaymentPeriod CostPeriod { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string UnitOfMeasure { get; set; }
        public string Subjective { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }

        internal override IList<string> VersionedFields { get; } = new List<string>
        {
            nameof(Cost), nameof(StartDate), nameof(EndDate)
        };
    }
}
