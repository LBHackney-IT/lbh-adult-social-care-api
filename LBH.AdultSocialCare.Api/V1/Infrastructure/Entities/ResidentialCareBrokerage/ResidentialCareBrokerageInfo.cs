using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage
{
    public class ResidentialCareBrokerageInfo : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ResidentialCarePackageId { get; set; }
        public decimal ResidentialCore { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public virtual ICollection<ResidentialCareAdditionalNeedsCost> ResidentialCareAdditionalNeedsCosts { get; set; }
        [ForeignKey(nameof(ResidentialCarePackageId))] public ResidentialCarePackage ResidentialCarePackage { get; set; }
        [ForeignKey(nameof(CreatorId))] public User Creator { get; set; }
        [ForeignKey(nameof(UpdatorId))] public User Updater { get; set; }

    }
}
