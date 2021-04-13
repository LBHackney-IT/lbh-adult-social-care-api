using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response
{
    public class DayCarePackageOpportunityResponse
    {
        public Guid DayCarePackageOpportunityId { get; set; }
        public string HowLong { get; set; }
        public string HowManyTimesPerMonth { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
        public Guid DayCarePackageId { get; set; }
    }
}
