using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CarePackageSchedulingOptionResponse
    {
        public PackageScheduling Id { get; set; }
        public string OptionName { get; set; }
        public string OptionPeriod { get; set; }
    }
}
