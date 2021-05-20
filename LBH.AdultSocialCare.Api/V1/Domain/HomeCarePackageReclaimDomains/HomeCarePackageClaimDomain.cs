using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains
{
    public class HomeCarePackageClaimDomain
    {
        public Guid HomeCarePackageReclaimId { get; set; }
        public Guid HomeCarePackageId { get; set; }
        public int ReclaimFromId { get; set; }
        public int ReclaimCategoryId { get; set; }
        public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }

        public HomeCarePackageReclaimFromDomain HomeCarePackageReclaimFrom { get; set; }

        public HomeCarePackageReclaimCategoryDomain HomeCarePackageReclaimCategory { get; set; }

        public HomeCarePackageReclaimAmountOptionDomain HomeCarePackageReclaimAmountOption { get; set; }
    }
}
