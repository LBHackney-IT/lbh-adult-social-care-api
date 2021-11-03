using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response
{
    public class PayRunDetailsViewResponse
    {
        public Guid PayRunId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public PagedResponse<PayRunInvoiceResponse> PayRunItems { get; set; }
    }
}
