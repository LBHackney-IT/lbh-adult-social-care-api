using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request
{
    public class CarePackageForCreationRequest
    {
        // Core package
        [Required, GuidNotEmpty]
        public Guid ServiceUserId { get; set; }

        [Required]
        public string PrimarySupportReason { get; set; }

        [Range(1, 4)]
        public PackageType PackageType { get; set; }

        // Package settings
        [Required]
        public bool? HasRespiteCare { get; set; }

        [Required]
        public bool? HasDischargePackage { get; set; }

        [Required]
        public bool? IsImmediate { get; set; }

        [Required]
        public bool? IsReEnablement { get; set; }

        [Required]
        public bool? IsS117Client { get; set; }
    }
}
