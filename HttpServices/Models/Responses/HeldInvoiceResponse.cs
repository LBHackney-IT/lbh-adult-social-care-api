using System;
using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class HeldInvoiceResponse
    {
        public Guid PayRunId { get; set; }
        public DateTimeOffset PayRunDate { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public IEnumerable<InvoiceResponse> Invoices { get; set; }
    }
}
