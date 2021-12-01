using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackage))]
    [GenerateMappingFor(typeof(CarePackageSettings))]
    public class CarePackageUpdateDomain
    {
        public int PrimarySupportReasonId { get; set; }

        public bool HasRespiteCare { get; set; }

        public bool HasDischargePackage { get; set; }

        public bool HospitalAvoidance { get; set; }

        public bool IsReEnablement { get; set; }

        public bool IsS117Client { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public PackageType PackageType { get; set; }
    }
}
