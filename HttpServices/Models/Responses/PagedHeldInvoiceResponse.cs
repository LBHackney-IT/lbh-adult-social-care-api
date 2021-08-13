using HttpServices.Models.Features;
using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class PagedHeldInvoiceResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<HeldInvoiceResponse> Data { get; set; }
    }
}
