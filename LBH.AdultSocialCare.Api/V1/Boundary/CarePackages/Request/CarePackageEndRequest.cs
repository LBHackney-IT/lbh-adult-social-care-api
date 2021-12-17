using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    public class CarePackageEndRequest : CarePackageChangeStatusRequest
    {
        [Required]
        public DateTimeOffset? EndDate { get; set; }
    }
}
