using HttpServices.Models.Features;
using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class PagedBillSummaryResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<BillSummaryResponse> Data { get; set; }
    }
}
