using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class DayCarePackageOpportunity
    {
        public Guid DayCarePackageOpportunityId { get; set; }
        public int OpportunityLengthOptionId { get; set; }
        public int OpportunityTimePerMonthOptionId { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
        public Guid DayCarePackageId { get; set; }
        [ForeignKey((nameof(DayCarePackageId)))] public DayCarePackage DayCarePackage { get; set; }
        [ForeignKey((nameof(OpportunityLengthOptionId)))] public OpportunityLengthOption OpportunityLengthOption { get; set; }
        [ForeignKey((nameof(OpportunityTimePerMonthOptionId)))] public OpportunityTimePerMonthOption OpportunityTimePerMonthOption { get; set; }
    }
}
