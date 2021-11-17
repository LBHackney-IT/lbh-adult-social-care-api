using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    [GenerateMappingFor(typeof(HeldInvoice))]
    [GenerateMappingFor(typeof(HeldInvoiceFlatResponse))]
    public class HeldInvoiceFlatDomain
    {
        public Guid Id { get; set; }
        public Guid PayRunInvoiceId { get; set; }
        public int ActionRequiredFromId { get; set; }
        public string ReasonForHolding { get; set; }
    }
}
