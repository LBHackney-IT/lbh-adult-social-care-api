using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    [GenerateListMappingFor(typeof(HeldInvoiceDetailsResponse))]
    public class HeldInvoiceDetailsDomain
    {
        public Guid PayRunId { get; set; }
        public string PayRunNumber { get; set; } // First six letters of pay run id
        public DateTimeOffset DateCreated { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PayRunInvoiceDomain PayRunInvoice { get; set; }
    }
}
