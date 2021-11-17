using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request
{
    public class PayRunChangeStatusRequest
    {
        [Required] public string Notes { get; set; }
    }
}
