using System;

namespace HttpServices.Models.Features.RequestFeatures
{
    public class BillSummaryListParameters : RequestParameters
    {
        public Guid? PackageId { get; set; }
        public int? SupplierId { get; set; }
        public int? BillPaymentStatusId { get; set; }
        public DateTimeOffset? FromDate { get; set; }
        public DateTimeOffset? ToDate { get; set; }
    }
}
