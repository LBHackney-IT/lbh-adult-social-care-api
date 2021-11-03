using HttpServices.Models.Features;
using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class PagedPayRunSummaryResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<PayRunSummaryResponse> Data { get; set; }
    }
}
