using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class NursingCareAdditionalNeed : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid NursingCarePackageId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string NeedToAddress { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [ForeignKey(nameof(NursingCarePackageId))] public NursingCarePackage NursingCarePackage { get; set; }
        [ForeignKey(nameof(AdditionalNeedsPaymentTypeId))] public AdditionalNeedsPaymentType AdditionalNeedsPaymentType { get; set; }
    }
}
