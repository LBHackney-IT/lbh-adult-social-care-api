using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
{
    [GenerateMappingFor(typeof(HeldInvoiceFlatDomain))]
    public class HeldInvoice : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PayRunInvoiceId { get; set; }
        public int ActionRequiredFromId { get; set; }
        public string ReasonForHolding { get; set; }

        [ForeignKey(nameof(PayRunInvoiceId))]
        public PayrunInvoice PayrunInvoice { get; set; }

        [ForeignKey(nameof(ActionRequiredFromId))]
        public Department ActionDepartment { get; set; }
    }
}
