using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing
{
    public class CareChargeElementDomain
    {
        public Guid Id { get; set; }
        public Guid CareChargeId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int ClaimCollectorId { get; set; }
        public string ClaimReasons { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset? PaidUpTo { get; set; }
        public DateTimeOffset? PreviousPaidUpTo { get; set; }
        public PackageCareCharge PackageCareCharge { get; set; }
        public CareChargeStatus CareChargeStatus { get; set; }
        public CareChargeType CareChargeType { get; set; }
        public PackageCostClaimer ClaimCollector { get; set; }
    }
}
