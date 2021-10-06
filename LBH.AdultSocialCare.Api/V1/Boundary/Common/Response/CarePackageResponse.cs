using System;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
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
