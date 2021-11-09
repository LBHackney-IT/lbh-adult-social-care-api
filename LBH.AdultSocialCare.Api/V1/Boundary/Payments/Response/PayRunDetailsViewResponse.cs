using System;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PayRunDetailsViewResponse
    {
        public Guid PayRunId { get; set; }
        public string PayRunNumber { get; set; } // First six letters of pay run id
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public PagedResponse<PayRunInvoiceResponse> PayRunItems { get; set; }
    }
}
