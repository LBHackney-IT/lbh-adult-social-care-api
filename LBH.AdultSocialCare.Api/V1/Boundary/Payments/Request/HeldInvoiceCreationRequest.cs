using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using System.ComponentModel.DataAnnotations;
using Common.Attributes;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request
{
    [GenerateMappingFor(typeof(HeldInvoiceCreationDomain))]
    public class HeldInvoiceCreationRequest
    {
        [Required, Range(1, int.MaxValue)] public int ActionRequiredFromId { get; set; }
        [Required] public string ReasonForHolding { get; set; }
    }
}
