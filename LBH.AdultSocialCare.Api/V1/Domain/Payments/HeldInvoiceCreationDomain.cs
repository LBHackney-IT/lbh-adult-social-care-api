using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    [GenerateMappingFor(typeof(HeldInvoice))]
    public class HeldInvoiceCreationDomain
    {
        public Guid PayRunInvoiceId { get; set; }
        public int ActionRequiredFromId { get; set; }
        public string ReasonForHolding { get; set; }
    }
}
