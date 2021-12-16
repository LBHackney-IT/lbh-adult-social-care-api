using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PackagePaymentItemResponse
    {
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public Guid PayRunId { get; set; }
        public Guid InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
