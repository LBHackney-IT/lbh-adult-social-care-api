using System;
using System.ComponentModel.DataAnnotations;

namespace HttpServices.Models.Requests
{
    public class DisputedInvoiceChatForCreationRequest
    {
        [Required] public Guid? PayRunItemId { get; set; }
        [Required] public string Message { get; set; }
        [Required] public int? ActionRequiredFromId { get; set; }
    }
}
