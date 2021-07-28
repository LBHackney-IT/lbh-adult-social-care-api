using System;

namespace HttpServices.Models.Responses
{
    public class PayRunDateSummaryResponse
    {
        public Guid PayRunId { get; set; }
        public int PayRunTypeId { get; set; }
        public string PayRunTypeName { get; set; }
        public int? PayRunSubTypeId { get; set; }
        public string PayRunSubTypeName { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
