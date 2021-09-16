using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage
{
    public class NursingCareAdditionalNeedsCost : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid NursingCareAdditionalNeedsCostId { get; set; }
        public Guid NursingCareBrokerageId { get; set; }
        public Guid NursingCareAdditionalNeedsId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal AdditionalNeedsCost { get; set; }
        [ForeignKey(nameof(AdditionalNeedsPaymentTypeId))] public AdditionalNeedsPaymentType AdditionalNeedsPaymentType { get; set; }
        [ForeignKey(nameof(NursingCareBrokerageId))] public NursingCareBrokerageInfo NursingCareBrokerageInfo { get; set; }
        [ForeignKey(nameof(NursingCareAdditionalNeedsId))] public NursingCareAdditionalNeed NursingCareAdditionalNeed { get; set; }

    }
}
