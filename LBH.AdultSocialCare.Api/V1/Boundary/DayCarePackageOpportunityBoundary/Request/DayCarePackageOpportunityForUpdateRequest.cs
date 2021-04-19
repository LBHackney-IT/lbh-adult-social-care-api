using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Request
{
    public class DayCarePackageOpportunityForUpdateRequest
    {
        [Required] public int? HowLongId { get; set; }
        [Required] public int? HowManyTimesPerMonthId { get; set; } // Daily, weekly, monthly
        [Required] public string OpportunitiesNeedToAddress { get; set; }
    }
}
