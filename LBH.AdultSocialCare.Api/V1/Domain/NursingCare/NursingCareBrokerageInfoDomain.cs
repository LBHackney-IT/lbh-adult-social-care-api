using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCare
{
    public class NursingCareBrokerageInfoDomain
    {
        public Guid NursingCareBrokerageId { get; set; }
        public Guid NursingCarePackageId { get; set; }
        public NursingCarePackageDomain NursingCarePackage { get; set; }
        public decimal NursingCore { get; set; }
        public decimal AdditionalNeedsPayment { get; set; }
        public decimal AdditionalNeedsPaymentOneOff { get; set; }
        public int? StageId { get; set; }
        public int? SupplierId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
    }
}
