using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.V1.Validations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request
{
    public class DayCarePackageForUpdateRequest
    {
        [Required, GuidNotEmpty] public Guid ClientId { get; set; }
        [Required] public bool? IsFixedPeriodOrOngoing { get; set; }
        [Required] public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [Required] public bool? IsThisAnImmediateService { get; set; }
        [Required] public bool? IsThisUserUnderS117 { get; set; }
        [Required(AllowEmptyStrings = false)] public string NeedToAddress { get; set; }
        [Required] public bool? Monday { get; set; }
        [Required] public bool? Tuesday { get; set; }
        [Required] public bool? Wednesday { get; set; }
        [Required] public bool? Thursday { get; set; }
        [Required] public bool? Friday { get; set; }
        [Required] public bool? Saturday { get; set; }
        [Required] public bool? Sunday { get; set; }
        [Required] public bool? TransportNeeded { get; set; }
        [Required] public bool? EscortNeeded { get; set; }
        [Required] public int? TermTimeConsiderationOptionId { get; set; }
        [Required] public int StatusId { get; set; }
    }
}
