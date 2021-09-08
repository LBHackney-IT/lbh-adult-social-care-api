using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class ProvisionalCareChargeAmountPlainDomain
    {
        public int Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public decimal Amount { get; set; }
    }
}
