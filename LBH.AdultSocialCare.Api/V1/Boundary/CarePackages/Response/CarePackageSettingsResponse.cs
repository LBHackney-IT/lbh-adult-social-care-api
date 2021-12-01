using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageSettingsResponse
    {
        public Guid Id { get; set; }
        public Guid CarePackageId { get; set; }
        public bool HasRespiteCare { get; set; }
        public bool HasDischargePackage { get; set; }
        public bool HospitalAvoidance { get; set; }
        public bool IsReEnablement { get; set; }
        public bool IsS117Client { get; set; }
        public bool IsS117ClientConfirmed { get; set; }
    }
}
