using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackageResponse))]
    public class CarePackageDomain
    {
        public Guid Id { get; set; }
        public PackageType PackageType { get; set; }
        public PackageScheduling PackageScheduling { get; set; }

        public ServiceUserBasicDomain ServiceUser { get; set; }
        public PrimarySupportReasonDomain PrimarySupportReason { get; set; }
        public CarePackageSettingsDomain Settings { get; set; }
    }
}
