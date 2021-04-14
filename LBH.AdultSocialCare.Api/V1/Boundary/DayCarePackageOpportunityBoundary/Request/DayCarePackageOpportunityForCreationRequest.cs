namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Request
{
    public class DayCarePackageOpportunityForCreationRequest
    {
        public string HowLong { get; set; }
        public string HowManyTimesPerMonth { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
    }
}
