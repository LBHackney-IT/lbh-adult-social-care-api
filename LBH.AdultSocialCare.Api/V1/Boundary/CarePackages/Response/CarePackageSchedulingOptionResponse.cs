using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageSchedulingOptionResponse
    {
        public PackageScheduling Id { get; set; }
        public string OptionName { get; set; }
        public string OptionPeriod { get; set; }
    }
}
