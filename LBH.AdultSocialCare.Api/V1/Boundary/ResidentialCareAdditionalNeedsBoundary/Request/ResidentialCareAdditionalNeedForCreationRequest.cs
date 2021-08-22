using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Request
{
    public class ResidentialCareAdditionalNeedForCreationRequest
    {
        [Required] public int AdditionalNeedsPaymentTypeId { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public Guid? CreatorId { get; set; }
    }
}
