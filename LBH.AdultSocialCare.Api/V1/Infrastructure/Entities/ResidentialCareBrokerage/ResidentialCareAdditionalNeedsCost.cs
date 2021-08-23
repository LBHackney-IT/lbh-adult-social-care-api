using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage
{
    public class ResidentialCareAdditionalNeedsCost : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid ResidentialCareAdditionalNeedsCostId { get; set; }
        public Guid ResidentialCareBrokerageId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
        [ForeignKey(nameof(AdditionalNeedsPaymentTypeId))] public AdditionalNeedsPaymentType AdditionalNeedsPaymentType { get; set; }
        [ForeignKey(nameof(ResidentialCareBrokerageId))] public ResidentialCareBrokerageInfo ResidentialCareBrokerageInfo { get; set; }
    }
}
