using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class BrokerageCareChargeForChangeRequest
    {
        [Required] public int? ClaimedBy { get; set; }
        public string CollectorReason { get; set; }
    }
}
