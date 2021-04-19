using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains
{
    public class DayCarePackageOpportunityForCreationDomain
    {
        public int OpportunityLengthOptionId { get; set; }
        public int OpportunityTimePerMonthOptionId { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
        public Guid DayCarePackageId { get; set; }
    }
}
