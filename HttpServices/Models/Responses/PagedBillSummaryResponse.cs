using System;
using System.Collections.Generic;
using System.Text;
using HttpServices.Models.Features;

namespace HttpServices.Models.Responses
{
    public class PagedBillSummaryResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<BillSummaryResponse> Data { get; set; }
    }
}
