using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using System;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityTimesPerMonthOptionDomains;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains
{
    public class DayCarePackageOpportunityDomain
    {
        public Guid DayCarePackageOpportunityId { get; set; }
        public OpportunityLengthOptionDomain HowLong { get; set; }
        public OpportunityTimesPerMonthOptionDomain HowManyTimesPerMonth { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
        public Guid DayCarePackageId { get; set; }
    }
}
