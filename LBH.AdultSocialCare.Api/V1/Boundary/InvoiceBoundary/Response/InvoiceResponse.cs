using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.InvoiceBoundary.Response
{
    public class InvoiceResponse
    {
        public long? SupplierId { get; set; }
        public int? PackageTypeId { get; set; }
        public Guid? ServiceUserId { get; set; }
        public Guid? CreatorId { get; set; }
        public IEnumerable<InvoiceItemResponse> InvoiceItems { get; set; }
    }
}
