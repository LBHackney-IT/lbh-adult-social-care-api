using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
{
    public class Payrun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public PayrunType Type { get; set; }
        public PayrunStatus Status { get; set; }

        public bool Paid { get; set; }
        public bool Held { get; set; }

        public DateTimeOffset PaidUpToDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public virtual ICollection<PayrunInvoice> PayrunInvoices { get; set; }
    }
}
