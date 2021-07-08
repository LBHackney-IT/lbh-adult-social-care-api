using System;
using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class HeldInvoiceResponse
    {
        public Guid PayRunId { get; set; }
        public DateTimeOffset PayRunDate { get; set; }
        public IEnumerable<InvoiceResponse> Invoices { get; set; }
    }
}
