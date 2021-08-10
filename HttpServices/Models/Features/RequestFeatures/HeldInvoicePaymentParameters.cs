using System;

namespace HttpServices.Models.Features.RequestFeatures
{
    public class HeldInvoicePaymentParameters : RequestParameters
    {
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
        public int? PackageTypeId { get; set; }
        public int? WaitingOnId { get; set; }
        public Guid? ServiceUserId { get; set; }
        public long? SupplierId { get; set; }
    }
}
