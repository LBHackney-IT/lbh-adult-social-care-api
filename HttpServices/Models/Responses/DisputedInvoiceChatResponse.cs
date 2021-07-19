using System;

namespace HttpServices.Models.Responses
{
    public class DisputedInvoiceChatResponse
    {
        public Guid DisputedInvoiceChatId { get; set; }
        public Guid DisputedInvoiceId { get; set; }
        public bool MessageRead { get; set; }
        public string Message { get; set; }
        public int? MessageFromId { get; set; }
        public int ActionRequiredFromId { get; set; }
    }
}
