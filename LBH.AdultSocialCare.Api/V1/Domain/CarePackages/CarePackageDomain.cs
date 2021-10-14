using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageResponse))]
    public class CarePackageDomain
    {
        public Guid Id { get; set; }
        public PackageType PackageType { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public int PrimarySupportReasonId { get; set; }

        public ServiceUserBasicDomain ServiceUser { get; set; }
        public CarePackageSettingsDomain Settings { get; set; }
    }
}
