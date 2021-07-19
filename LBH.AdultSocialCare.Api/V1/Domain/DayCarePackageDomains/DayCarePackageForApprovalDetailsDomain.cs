using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains
{
    public class DayCarePackageForApprovalDetailsDomain
    {
        public ApprovalPackageDetailsDto PackageDetails { get; set; }
        public ApproveClientDetailsDto ClientDetails { get; set; }
        public DayCareApproveCostSummaryDto CostSummary { get; set; }
        public IEnumerable<DayCarePackageApprovalHistoryDto> PackageApprovalHistory { get; set; }
    }

    public class ApprovalPackageDetailsDto
    {
        public Guid DayCarePackageId { get; set; }
        public bool IsFixedPeriodOrOngoing { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string NeedToAddress { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool TransportNeeded { get; set; }
        public bool EscortNeeded { get; set; }
        public string TermTimeConsiderationOptionName { get; set; }
        public IEnumerable<DayCarePackageOpportunityDomain> DayCareOpportunities { get; set; }
    }

    public class ApproveClientDetailsDto
    {
        public string ClientName { get; set; }
        public int HackneyId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string PreferredContact { get; set; }  // eg phone
        public string CanSpeakEnglish { get; set; }  // eg fluent
    }

    public class DayCareApproveCostSummaryDto
    {
        public decimal CostOfCarePerWeek { get; set; }
        public decimal ANPPerWeek { get; set; }
        public decimal TransportCostPerWeek { get; set; }
        public decimal TotalCostPerWeek { get; set; }
    }

    public class DayCarePackageApprovalHistoryDto
    {
        public Guid HistoryId { get; set; }
        public Guid DayCarePackageId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Guid CreatorId { get; set; }
        public string CreatorName { get; set; }
        public int PackageStatusId { get; set; }
        public string PackageStatusName { get; set; }
        public string LogText { get; set; }
        public string LogSubText { get; set; }
        public string CreatorRole { get; set; }
    }
}
