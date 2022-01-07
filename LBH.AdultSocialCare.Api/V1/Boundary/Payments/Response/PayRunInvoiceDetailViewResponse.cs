using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PayRunInvoiceDetailViewResponse
    {
        public Guid PayRunId { get; set; }
        public string PayRunNumber { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public PayRunInvoiceResponse Invoice { get; set; }
    }
}
