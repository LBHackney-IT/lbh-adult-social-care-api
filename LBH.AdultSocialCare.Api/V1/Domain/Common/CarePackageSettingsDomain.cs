using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackageSettingsResponse))]
    [GenerateListMappingFor(typeof(CarePackageSettingsResponse))]
    public class CarePackageSettingsDomain
    {
        public Guid Id { get; set; }
        public Guid CarePackageId { get; set; }
        public PackageType PackageType { get; set; }
        public int PrimarySupportReasonId { get; set; }
        public string PrimarySupportReasonName { get; set; }
        public bool HasRespiteCare { get; set; }
        public bool HasDischargePackage { get; set; }
        public bool HospitalAvoidance { get; set; }
        public bool IsReEnablement { get; set; }
        public bool IsS117Client { get; set; }
    }
}
