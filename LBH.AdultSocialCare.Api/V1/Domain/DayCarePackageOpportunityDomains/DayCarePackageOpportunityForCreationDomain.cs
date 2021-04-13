namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains
{
    public class DayCarePackageOpportunityForCreationDomain
    {
        public string HowLong { get; set; }
        public string HowManyTimesPerMonth { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
    }
}
