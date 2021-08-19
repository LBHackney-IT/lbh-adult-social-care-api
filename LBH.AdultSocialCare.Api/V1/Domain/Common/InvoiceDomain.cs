using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class InvoiceDomain
    {
        public long? SupplierId { get; set; }
        public int? PackageTypeId { get; set; }
        public Guid? ServiceUserId { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public Guid? PackageId { get; set; }
        public IEnumerable<InvoiceItemDomain> InvoiceItems { get; set; }
    }
}
