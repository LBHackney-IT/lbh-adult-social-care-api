using System;
using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response
{
    public class NursingCarePackageClaimResponse
    {
        public Guid NursingCarePackageReclaimId { get; set; }
        public Guid NursingCarePackageId { get; set; }
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
