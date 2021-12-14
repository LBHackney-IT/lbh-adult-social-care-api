using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackage))]
    [GenerateMappingFor(typeof(CarePackageResponse))]
    public class CarePackageDomain
    {
        public Guid Id { get; set; }
        public PackageType PackageType { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public PackageStatus Status { get; set; }
        public int PrimarySupportReasonId { get; set; }
        public Guid? SocialWorkerCarePlanFileId { get; set; }
        public string SocialWorkerCarePlanFileName { get; set; }
        public ServiceUserBasicDomain ServiceUser { get; set; }
        public CarePackageSettingsDomain Settings { get; set; }
    }
}
