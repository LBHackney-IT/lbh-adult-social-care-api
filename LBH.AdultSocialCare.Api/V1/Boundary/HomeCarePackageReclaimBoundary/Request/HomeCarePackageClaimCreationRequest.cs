using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Request
{
    public class HomeCarePackageClaimCreationRequest
    {
        public Guid HomeCarePackageId { get; set; }
        [Required] public int ReclaimFromId { get; set; }
        [Required] public int ReclaimCategoryId { get; set; }
        [Required] public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        [Required] public decimal Amount { get; set; }
    }
}
