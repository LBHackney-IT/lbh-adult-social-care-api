using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CareChargeElementForUpdateDomain
    {
        public decimal Amount { get; set; }
        public int CollectorId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
