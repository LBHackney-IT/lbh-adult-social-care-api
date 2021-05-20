using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageReclaimBoundary.Response
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

        public HomeCarePackageReclaimFromResponse HomeCarePackageReclaimFrom { get; set; }

        public HomeCarePackageReclaimCategoryResponse HomeCarePackageReclaimCategory { get; set; }

        public HomeCarePackageReclaimAmountOptionResponse HomeCarePackageReclaimAmountOption { get; set; }
    }
}
