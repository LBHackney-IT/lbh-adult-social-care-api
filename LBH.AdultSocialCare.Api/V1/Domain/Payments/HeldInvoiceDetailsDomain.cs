using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class HeldInvoiceDetailsDomain
    {
        public Guid PayRunId { get; set; }
        public string PayRunNumber { get; set; } // First six letters of pay run id
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public PayRunInvoiceDomain PayRunInvoice { get; set; }
    }
}
