using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CareChargeElementPlainDomain
    {
        public Guid Id { get; set; }
        public Guid CareChargeId { get; set; }
        public int? StatusId { get; set; }
        public int TypeId { get; set; }
        public int ClaimCollectorId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset? PaidUpTo { get; set; }
        public DateTimeOffset? PreviousPaidUpTo { get; set; }
        public decimal Amount { get; set; }
    }
}
