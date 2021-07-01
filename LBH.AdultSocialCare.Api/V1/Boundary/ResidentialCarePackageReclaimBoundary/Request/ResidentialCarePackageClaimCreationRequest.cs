using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageReclaimBoundary.Request
{
    public class ResidentialCarePackageClaimCreationRequest
    {
        public Guid ResidentialCarePackageId { get; set; }
        [Required] public int ReclaimFromId { get; set; }
        [Required] public int ReclaimCategoryId { get; set; }
        [Required] public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        [Required] public decimal Amount { get; set; }
    }
}
