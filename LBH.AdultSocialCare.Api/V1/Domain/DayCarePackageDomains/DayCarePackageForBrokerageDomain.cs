using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains
{
    public class DayCarePackageForBrokerageDomain
    {
        public DayCareBrokeragePackageDetailsDto PackageDetails { get; set; }
        public ApproveClientDetailsDto ClientDetails { get; set; }
        public IEnumerable<DayCarePackageApprovalHistoryDto> PackageApprovalHistory { get; set; }
    }

    public class DayCareBrokeragePackageDetailsDto
    {
        public Guid DayCarePackageId { get; set; }
        public bool IsFixedPeriodOrOngoing { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string NeedToAddress { get; set; }
        public int DaysPerWeek { get; set; }
        public int DayCareOpportunitiesHoursPerWeek { get; set; }
        public bool TransportNeeded { get; set; }
        public bool TransportEscortNeeded { get; set; }
        public bool EscortNeeded { get; set; }
        public string TermTimeConsiderationOptionName { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public IEnumerable<DayCarePackageOpportunityDomain> DayCareOpportunities { get; set; }
    }
}
