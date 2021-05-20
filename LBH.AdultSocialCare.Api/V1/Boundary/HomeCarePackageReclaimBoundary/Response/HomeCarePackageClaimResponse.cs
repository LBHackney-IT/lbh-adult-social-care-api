using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response
{
    public class HomeCarePackageClaimResponse
    {
        public Guid HomeCarePackageReclaimId { get; set; }
        public Guid HomeCarePackageId { get; set; }
        public int ReclaimFromId { get; set; }
        public int ReclaimCategoryId { get; set; }
        public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }

        public HomeCarePackageReclaimFromResponse HomeCarePackageReclaimFrom { get; set; }

        public HomeCarePackageReclaimCategoryResponse HomeCarePackageReclaimCategory { get; set; }

        public HomeCarePackageReclaimAmountOptionResponse HomeCarePackageReclaimAmountOption { get; set; }
    }
}
