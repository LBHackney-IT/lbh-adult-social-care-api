using System;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCare
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
