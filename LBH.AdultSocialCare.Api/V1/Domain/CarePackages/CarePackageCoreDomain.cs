using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageCoreResponse))]
    [GenerateListMappingFor(typeof(CarePackageCoreResponse))]
    public class CarePackageCoreDomain
    {
        public Guid CarePackageId { get; set; }
        public Guid ServiceUserId { get; set; }
        public PackageType PackageType { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public int PrimarySupportReasonId { get; set; }
        public string PrimarySupportReasonName { get; set; }
        public bool HasRespiteCare { get; set; }
        public bool HasDischargePackage { get; set; }
        public bool HospitalAvoidance { get; set; }
        public bool IsReEnablement { get; set; }
        public bool IsS117Client { get; set; }
    }
}
