using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class HeldInvoiceFlatResponse
    {
        public Guid Id { get; set; }
        public Guid PayRunInvoiceId { get; set; }
        public int ActionRequiredFromId { get; set; }
        public string ReasonForHolding { get; set; }
    }
}
