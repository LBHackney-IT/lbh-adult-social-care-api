using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CarePackageUpdateDomain))]
    public class CarePackageUpdateRequest
    {
        [Range(1, int.MaxValue)]
        public int PrimarySupportReasonId { get; set; }

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

        [Required]
        [EnumDataType(typeof(PackageScheduling))]
        public PackageScheduling PackageScheduling { get; set; }

        [Required]
        [EnumDataType(typeof(PackageType))]
        public PackageType PackageType { get; set; }
    }
}
