using System;

namespace HttpServices.Models.Responses
{
    public class DisputedInvoiceFlatResponse
    {
        public Guid DisputedInvoiceId { get; set; }
        public Guid PayRunItemId { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid? InvoiceItemId { get; set; }
        public int ActionRequiredFromId { get; set; }
        public string ReasonForHolding { get; set; }
    }
}
