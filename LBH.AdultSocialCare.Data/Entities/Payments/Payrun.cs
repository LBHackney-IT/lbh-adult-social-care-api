using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Data.Entities.Payments
{
    public class Payrun : BaseEntity
    {
        public Payrun()
        {
            Histories = new HashSet<PayrunHistory>();
            PayrunInvoices = new HashSet<PayrunInvoice>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public PayrunType Type { get; set; }
        public PayrunStatus Status { get; set; }

        [Column(TypeName = "decimal(13, 2)")] public decimal? Paid { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal? Held { get; set; }

        public DateTimeOffset PaidUpToDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public virtual ICollection<PayrunInvoice> PayrunInvoices { get; set; }
        public virtual ICollection<PayrunHistory> Histories { get; set; }
    }
}
