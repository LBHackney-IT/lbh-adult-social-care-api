using HttpServices.Models.Features;
using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class PagedSupplierResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<SupplierMinimalResponse> Data { get; set; }
    }
}
