using System;
using System.Collections.Generic;
using System.Text;
using HttpServices.Models.Features;

namespace HttpServices.Models.Responses
{
    public class PagedSupplierResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<SupplierMinimalResponse> Data { get; set; }
    }
}
