using System;

namespace HttpServices.Models.Requests
{
    public class PayRunForCreationRequest
    {
        public DateTimeOffset DateTo { get; set; } = DateTimeOffset.Now;
    }
}
