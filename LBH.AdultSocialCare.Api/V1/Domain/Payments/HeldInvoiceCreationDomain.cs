using System;
using Common.Attributes;
using LBH.AdultSocialCare.Data.Entities.Payments;

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
