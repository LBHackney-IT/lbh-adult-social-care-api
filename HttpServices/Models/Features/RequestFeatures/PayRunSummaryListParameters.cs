using System;

namespace HttpServices.Models.Features.RequestFeatures
{
    public class PayRunSummaryListParameters : RequestParameters
    {
        public Guid? PayRunId { get; set; }
        public int? PayRunTypeId { get; set; }
        public int? PayRunSubTypeId { get; set; }
        public int? PayRunStatusId { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
    }
}
