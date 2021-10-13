using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class FundedNursingCarePriceDomain
    {
        public int Id { get; set; }
        public decimal PricePerWeek { get; set; }
        public DateTimeOffset ActiveFrom { get; set; }
        public DateTimeOffset ActiveTo { get; set; }
    }
}
