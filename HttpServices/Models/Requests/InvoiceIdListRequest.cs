using System;
using System.Collections.Generic;

namespace HttpServices.Models.Requests
{
    public class InvoiceIdListRequest
    {
        public IEnumerable<Guid> InvoiceIds { get; set; }
    }
}
