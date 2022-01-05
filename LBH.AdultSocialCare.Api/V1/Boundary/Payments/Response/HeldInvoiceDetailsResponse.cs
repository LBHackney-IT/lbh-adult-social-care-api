using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class HeldInvoiceDetailsResponse
    {
        public Guid PayRunId { get; set; }
        public string PayRunNumber { get; set; } // First six letters of pay run id
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public PayRunInvoiceResponse PayRunInvoice { get; set; }
    }
}
