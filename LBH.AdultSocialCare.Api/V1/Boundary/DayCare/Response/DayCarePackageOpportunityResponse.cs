using System;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response
{
    public class DayCarePackageOpportunityResponse
    {
        public Guid DayCarePackageOpportunityId { get; set; }
        public OpportunityLengthOptionResponse HowLong { get; set; }
        public OpportunityTimesPerMonthOptionResponse HowManyTimesPerMonth { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
        public Guid DayCarePackageId { get; set; }
    }
}
