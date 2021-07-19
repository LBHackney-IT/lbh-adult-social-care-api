using System;

namespace HttpServices.Models.Responses
{
    public class PayRunSummaryResponse
    {
        public Guid PayRunId { get; set; }
        public long PayRunNumber { get; set; }
        public int PayRunTypeId { get; set; }
        public string PayRunTypeName { get; set; }
        public int? PayRunSubTypeId { get; set; }
        public string PayRunSubTypeName { get; set; }
        public int PayRunStatusId { get; set; }
        public string PayRunStatusName { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public decimal TotalAmountHeld { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
