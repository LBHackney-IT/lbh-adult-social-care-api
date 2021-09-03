using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request
{
    public class NursingCareAdditionalNeedForCreationRequest
    {
        [Required] public int AdditionalNeedsPaymentTypeId { get; set; }
        [Required] public string NeedToAddress { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
