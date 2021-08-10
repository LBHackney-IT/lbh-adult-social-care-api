using System;

namespace HttpServices.Models.Responses
{
    public class PayRunFlatResponse
    {
        public Guid PayRunId { get; set; }
        public long PayRunNumber { get; set; }
        public int PayRunTypeId { get; set; }
        public int? PayRunSubTypeId { get; set; }
        public int PayRunStatusId { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
        public string PayRunStatusName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
