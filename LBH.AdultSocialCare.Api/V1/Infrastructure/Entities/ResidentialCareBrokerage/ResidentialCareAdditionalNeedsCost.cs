using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage
{
    public class ResidentialCareAdditionalNeedsCost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid ResidentialCareAdditionalNeedsCostId { get; set; }
        public Guid ResidentialCareBrokerageId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        [ForeignKey(nameof(AdditionalNeedsPaymentTypeId))] public AdditionalNeedsPaymentType AdditionalNeedsPaymentType { get; set; }
        [ForeignKey(nameof(ResidentialCareBrokerageId))] public ResidentialCareBrokerageInfo ResidentialCareBrokerageInfo { get; set; }
        [ForeignKey(nameof(CreatorId))] public User Creator { get; set; }
        [ForeignKey(nameof(UpdatorId))] public User Updater { get; set; }
    }
}
