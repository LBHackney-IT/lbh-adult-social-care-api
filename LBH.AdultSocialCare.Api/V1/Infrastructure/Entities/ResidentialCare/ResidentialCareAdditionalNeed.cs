using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare
{
    public class ResidentialCareAdditionalNeed : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ResidentialCarePackageId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string NeedToAddress { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public virtual ResidentialCareAdditionalNeedsCost ResidentialCareAdditionalNeedsCost { get; set; }
        [ForeignKey(nameof(ResidentialCarePackageId))] public ResidentialCarePackage ResidentialCarePackage { get; set; }
        [ForeignKey(nameof(AdditionalNeedsPaymentTypeId))] public AdditionalNeedsPaymentType AdditionalNeedsPaymentType { get; set; }
    }
}
