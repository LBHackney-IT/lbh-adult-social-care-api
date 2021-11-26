using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PayRunListResponse
    {
        public Guid PayRunId { get; set; }
        public string PayRunNumber { get; set; }
        public int PayRunTypeId { get; set; }
        public string PayRunTypeName { get; set; }
        public int PayRunStatusId { get; set; }
        public string PayRunStatusName { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public decimal TotalAmountHeld { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
