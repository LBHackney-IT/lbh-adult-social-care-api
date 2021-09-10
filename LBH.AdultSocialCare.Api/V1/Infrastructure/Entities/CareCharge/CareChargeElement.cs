using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge
{
    [GenerateMappingFor(typeof(CareChargeElementPlainDomain))]
    [GenerateListMappingFor(typeof(CareChargeElementPlainDomain))]
    public class CareChargeElement : BaseEntity
    {
        [Key] public Guid Id { get; set; }
        public Guid CareChargeId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int ClaimCollectorId { get; set; }
        public string ClaimReasons { get; set; } // If claimer is hackney
        public string Name { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal Amount { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset? PaidUpTo { get; set; }
        public DateTimeOffset? PreviousPaidUpTo { get; set; }
        [ForeignKey(nameof(CareChargeId))] public PackageCareCharge PackageCareCharge { get; set; }
        [ForeignKey(nameof(StatusId))] public CareChargeStatus CareChargeStatus { get; set; }
        [ForeignKey(nameof(TypeId))] public CareChargeType CareChargeType { get; set; }
        [ForeignKey(nameof(ClaimCollectorId))] public PackageCostClaimer ClaimCollector { get; set; }
    }
}
