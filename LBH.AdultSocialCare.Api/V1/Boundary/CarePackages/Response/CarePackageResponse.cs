using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageResponse
    {
        public Guid Id { get; set; }
        public PackageType PackageType { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public int PrimarySupportReasonId { get; set; }

        public ServiceUserBasicResponse ServiceUser { get; set; }
        public CarePackageSettingsResponse Settings { get; set; }
    }
}
