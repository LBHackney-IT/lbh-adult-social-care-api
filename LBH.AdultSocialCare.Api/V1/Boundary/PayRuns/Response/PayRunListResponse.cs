using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response
{
    public class PayRunListResponse
    {
        public Guid PayRunId { get; set; }
        public int PayRunTypeId { get; set; }
        public string PayRunTypeName { get; set; }
        public int PayRunStatusId { get; set; }
        public string PayRunStatusName { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public decimal TotalAmountHeld { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
