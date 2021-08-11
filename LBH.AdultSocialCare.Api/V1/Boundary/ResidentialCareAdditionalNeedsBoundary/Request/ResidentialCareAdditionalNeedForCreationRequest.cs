using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Request
{
    public class ResidentialCareAdditionalNeedForCreationRequest
    {
        [Required] public bool? IsWeeklyCost { get; set; }
        [Required] public bool? IsOneOffCost { get; set; }
        [Required] public string NeedToAddress { get; set; }
    }
}
