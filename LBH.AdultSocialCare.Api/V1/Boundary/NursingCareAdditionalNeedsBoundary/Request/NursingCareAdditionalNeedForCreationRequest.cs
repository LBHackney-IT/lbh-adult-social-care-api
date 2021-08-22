using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Request
{
    public class NursingCareAdditionalNeedForCreationRequest
    {
        [Required] public int AdditionalNeedsPaymentTypeId { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public Guid? CreatorId { get; set; }
    }
}
