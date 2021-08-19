using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Request
{
    public class NursingCareAdditionalNeedForCreationRequest
    {
        public bool IsWeeklyCost { get; set; }
        public bool IsOneOffCost { get; set; }
        [Required] public string NeedToAddress { get; set; }
    }
}
