using System.ComponentModel.DataAnnotations;

namespace HttpServices.Models.Requests
{
    public class DisputedInvoiceChatForCreationRequest
    {
        [Required] public string Message { get; set; }
        [Required] public int? ActionRequiredFromId { get; set; }
    }
}
