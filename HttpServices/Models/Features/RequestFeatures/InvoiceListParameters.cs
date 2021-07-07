using System;

namespace HttpServices.Models.Features.RequestFeatures
{
    public class InvoiceListParameters : RequestParameters
    {
        public long? SupplierId { get; set; }
        public int? PackageTypeId { get; set; }
        public int? InvoiceStatusId { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
        public string SearchTerm { get; set; }
    }
}
