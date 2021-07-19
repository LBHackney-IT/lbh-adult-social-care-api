using System.Collections.Generic;
using HttpServices.Models.Features;

namespace HttpServices.Models.Responses
{
    public class PagedPayRunSummaryResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<PayRunSummaryResponse> Data { get; set; }
    }
}
