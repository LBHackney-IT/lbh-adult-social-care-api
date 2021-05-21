using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageReclaimBoundary.Request
{
    public class DayCarePackageClaimCreationRequest
    {
        [Required] public Guid DayCarePackageId { get; set; }
        [Required] public int ReclaimFromId { get; set; }
        [Required] public int ReclaimCategoryId { get; set; }
        [Required] public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        [Required] public decimal Amount { get; set; }
    }
}
