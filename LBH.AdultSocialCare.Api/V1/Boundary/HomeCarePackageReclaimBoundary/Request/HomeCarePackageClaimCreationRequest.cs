using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Request
{
    public class HomeCarePackageClaimCreationRequest
    {
        [Required] public Guid HomeCarePackageId { get; set; }
        [Required] public int ReclaimFromId { get; set; }
        [Required] public int ReclaimCategoryId { get; set; }
        [Required] public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        [Required] public decimal Amount { get; set; }
    }
}
