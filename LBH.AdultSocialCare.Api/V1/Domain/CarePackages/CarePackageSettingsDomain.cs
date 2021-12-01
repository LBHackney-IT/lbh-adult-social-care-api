using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageSettings))]
    [GenerateMappingFor(typeof(CarePackageSettingsResponse))]
    [GenerateListMappingFor(typeof(CarePackageSettingsResponse))]
    public class CarePackageSettingsDomain
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
