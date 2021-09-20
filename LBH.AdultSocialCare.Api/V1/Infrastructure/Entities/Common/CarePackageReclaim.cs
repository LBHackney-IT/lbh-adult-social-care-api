using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

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

        public ClaimCollector ClaimCollector { get; set; }

        public int SupplierId { get; set; }

        public ReclaimStatus Status { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }

        public string AssessmentFileUrl { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }

        public virtual ICollection<CarePackageReclaimElement> Elements { get; set; }
    }
}
