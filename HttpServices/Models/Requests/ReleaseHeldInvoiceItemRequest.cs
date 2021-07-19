using System;
using System.ComponentModel.DataAnnotations;

namespace HttpServices.Models.Requests
{
    public class ReleaseHeldInvoiceItemRequest
    {
        [Required] public Guid? PayRunId { get; set; }
        [Required] public Guid? InvoiceId { get; set; }
    }
}
