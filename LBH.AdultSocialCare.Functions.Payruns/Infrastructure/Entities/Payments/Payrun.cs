using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments
{
    public class Payrun : BaseEntity
    {
        public Payrun()
        {
            PayrunInvoices = new List<PayrunInvoice>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public PayrunType Type { get; set; }
        public PayrunStatus Status { get; set; }

        public decimal? Paid { get; set; }
        public decimal? Held { get; set; }

        public DateTimeOffset PaidUpToDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public virtual ICollection<PayrunInvoice> PayrunInvoices { get; set; }
        public virtual ICollection<PayrunHistory> Histories { get; set; }
    }
}
