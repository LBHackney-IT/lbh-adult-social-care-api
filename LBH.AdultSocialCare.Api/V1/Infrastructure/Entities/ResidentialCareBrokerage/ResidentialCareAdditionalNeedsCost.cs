using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage
{
    public class ResidentialCareAdditionalNeedsCost : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid ResidentialCareAdditionalNeedsCostId { get; set; }
        public Guid ResidentialCareBrokerageId { get; set; }
        public Guid ResidentialCareAdditionalNeedsId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal AdditionalNeedsCost { get; set; }
        [ForeignKey(nameof(AdditionalNeedsPaymentTypeId))] public AdditionalNeedsPaymentType AdditionalNeedsPaymentType { get; set; }
        [ForeignKey(nameof(ResidentialCareBrokerageId))] public ResidentialCareBrokerageInfo ResidentialCareBrokerageInfo { get; set; }
        [ForeignKey(nameof(ResidentialCareAdditionalNeedsId))] public ResidentialCareAdditionalNeed ResidentialCareAdditionalNeed { get; set; }
    }
}
