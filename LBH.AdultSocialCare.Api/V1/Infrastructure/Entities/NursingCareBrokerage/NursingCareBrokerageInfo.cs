using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage
{
    public class NursingCareBrokerageInfo : BaseEntityTmp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid NursingCareBrokerageId { get; set; }
        public Guid NursingCarePackageId { get; set; }
        public decimal NursingCore { get; set; }
        public decimal AdditionalNeedsPayment { get; set; }
        public decimal AdditionalNeedsPaymentOneOff { get; set; }
        [ForeignKey(nameof(NursingCarePackageId))] public NursingCarePackage NursingCarePackage { get; set; }
    }
}
