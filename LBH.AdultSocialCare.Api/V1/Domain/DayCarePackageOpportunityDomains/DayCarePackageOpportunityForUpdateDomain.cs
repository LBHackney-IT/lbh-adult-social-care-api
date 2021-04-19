using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains
{
    public class DayCarePackageOpportunityForUpdateDomain
    {
        public Guid DayCarePackageId { get; set; }
        public Guid DayCarePackageOpportunityId { get; set; }
        public int OpportunityLengthOptionId { get; set; }
        public int OpportunityTimePerMonthOptionId { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
    }
}
