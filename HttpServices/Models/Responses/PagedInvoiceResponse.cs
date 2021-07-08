using HttpServices.Models.Features;
using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class PagedInvoiceResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<InvoiceResponse> Invoices { get; set; }
    }
}
