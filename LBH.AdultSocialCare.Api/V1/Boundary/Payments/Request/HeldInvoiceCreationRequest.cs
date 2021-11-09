using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request
{
    [GenerateMappingFor(typeof(HeldInvoiceCreationDomain))]
    public class HeldInvoiceCreationRequest
    {
        [Required, GuidNotEmpty] public Guid ActionRequiredFromId { get; set; }
        [Required] public string ReasonForHolding { get; set; }
    }
}
