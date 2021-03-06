using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    public class CarePackageForCreationRequest
    {
        // Core package
        [Required, GuidNotEmpty]
        public Guid ServiceUserId { get; set; }

        [Required]
        public int? PrimarySupportReasonId { get; set; }

        [Required]
        [EnumDataType(typeof(PackageScheduling))]
        public PackageScheduling? PackageScheduling { get; set; }

        [EnumDataType(typeof(PackageType))]
        public PackageType PackageType { get; set; }

        // Package settings
        [Required]
        public bool? HasRespiteCare { get; set; }

        [Required]
        public bool? HasDischargePackage { get; set; }

        [Required]
        public bool? HospitalAvoidance { get; set; }

        [Required]
        public bool? IsReEnablement { get; set; }

        [Required]
        public bool? IsS117Client { get; set; }
    }
}
