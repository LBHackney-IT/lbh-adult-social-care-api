using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request
{
    public class ResidentialCareAdditionalNeedForCreationRequest
    {
        [Required] public int AdditionalNeedsPaymentTypeId { get; set; }
        [Required] public string NeedToAddress { get; set; }
    }
}
