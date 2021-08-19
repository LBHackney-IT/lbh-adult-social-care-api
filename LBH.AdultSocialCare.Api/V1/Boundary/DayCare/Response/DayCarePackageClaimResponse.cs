using System;
using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response
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
