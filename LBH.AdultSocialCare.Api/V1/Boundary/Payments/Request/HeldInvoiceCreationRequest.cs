using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request
{
    [GenerateMappingFor(typeof(HeldInvoiceCreationDomain))]
    public class HeldInvoiceCreationRequest
    {
        public Guid PayRunInvoiceId { get; set; }
        public Guid ActionRequiredFromId { get; set; }
        public string ReasonForHolding { get; set; }
    }
}
