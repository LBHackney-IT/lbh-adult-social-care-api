using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCarePackageReclaims
{
    public class DayCarePackageReclaim : BaseEntityTmp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DayCarePackageReclaimId { get; set; }

        public Guid DayCarePackageId { get; set; }
        public int ReclaimFromId { get; set; }
        public int ReclaimCategoryId { get; set; }
        public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey(nameof(ReclaimFromId))]
        public ReclaimFrom ReclaimFrom { get; set; }

        [ForeignKey(nameof(ReclaimCategoryId))]
        public ReclaimCategory ReclaimCategory { get; set; }

        [ForeignKey(nameof(ReclaimAmountOptionId))]
        public ReclaimAmountOption ReclaimAmountOption { get; set; }
    }
}
