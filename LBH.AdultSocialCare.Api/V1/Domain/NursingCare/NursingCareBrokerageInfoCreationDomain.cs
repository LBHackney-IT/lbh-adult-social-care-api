using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCare
{
    public class NursingCareBrokerageInfoCreationDomain
    {
        public Guid NursingCarePackageId { get; set; }
        public int SupplierId { get; set; }
        public int StageId { get; set; }
        public decimal NursingCore { get; set; }
        public decimal AdditionalNeedsPayment { get; set; }
        public decimal AdditionalNeedsPaymentOneOff { get; set; }
        public int FundedNursingCareCollectorId { get; set; }
        public Guid CreatorId { get; set; }
    }
}
