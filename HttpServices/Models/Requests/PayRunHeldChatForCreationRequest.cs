using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HttpServices.Models.Requests
{
    public class PayRunHeldChatForCreationRequest
    {
        [Required] public Guid PayRunId { get; set; }
        [Required] public Guid PackageId { get; set; }
        [Required] public string Message { get; set; }
    }
}
