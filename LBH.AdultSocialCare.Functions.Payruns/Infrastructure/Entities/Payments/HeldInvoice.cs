using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments
{
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
