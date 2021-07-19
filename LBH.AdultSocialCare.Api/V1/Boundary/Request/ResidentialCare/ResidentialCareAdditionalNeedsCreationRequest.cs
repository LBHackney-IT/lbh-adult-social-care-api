using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Request.ResidentialCare
{
    public class ResidentialCareAdditionalNeedsCreationRequest
    {
        [Required] public bool? IsWeeklyCost { get; set; }
        [Required] public bool? IsOneOffCost { get; set; }
        [Required] public bool? IsFixedPeriod { get; set; } // If fixed period is true there must be start date and end date. Validate on post request
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public Guid? CreatorId { get; set; }
    }
}
