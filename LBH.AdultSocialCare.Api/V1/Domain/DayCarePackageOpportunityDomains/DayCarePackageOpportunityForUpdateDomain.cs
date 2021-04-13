using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains
{
    public class DayCarePackageOpportunityForUpdateDomain
    {
        public Guid DayCarePackageId { get; set; }
        public Guid DayCarePackageOpportunityId { get; set; }
        public string HowLong { get; set; }
        public string HowManyTimesPerMonth { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
    }
}
