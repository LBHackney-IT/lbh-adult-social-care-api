using System.ComponentModel.DataAnnotations;

namespace HttpServices.Models.Requests
{
    public class DisputedInvoiceForCreationRequest
    {
        [Required] public int? ActionRequiredFromId { get; set; }
        [Required] public string ReasonForHolding { get; set; }
    }
}
