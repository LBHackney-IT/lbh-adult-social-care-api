using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageReclaimBoundary.Response
{
    public class DayCarePackageClaimResponse
    {
        public Guid DayCarePackageReclaimId { get; set; }
        public Guid DayCarePackageId { get; set; }
        public int ReclaimFromId { get; set; }
        public int ReclaimCategoryId { get; set; }
        public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }

        public ReclaimFromResponse ReclaimFrom { get; set; }

        public ReclaimCategoryResponse ReclaimCategory { get; set; }

        public ReclaimAmountOptionResponse ReclaimAmountOption { get; set; }
    }
}
