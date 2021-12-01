using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Data.Entities.Payments
{
    public class PayrunHistory : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid PayRunId { get; set; }

        public string Notes { get; set; }

        public PayrunStatus Status { get; set; }
        public PayRunHistoryType? Type { get; set; }

        [ForeignKey(nameof(PayRunId))]
        public Payrun Payrun { get; set; }
    }
}
