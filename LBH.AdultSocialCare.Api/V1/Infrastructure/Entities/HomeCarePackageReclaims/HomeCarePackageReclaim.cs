using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims
{
    public class HomeCarePackageReclaim : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid HomeCarePackageReclaimId { get; set; }
        public Guid HomeCarePackageId { get; set; }
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
