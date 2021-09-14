using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing
{
    public class AdditionalNeedsCost
    {
        public AdditionalNeedsPaymentTypeDomain AdditionalNeedsPaymentType { get; set; }

        public decimal Cost { get; set; }
    }
}