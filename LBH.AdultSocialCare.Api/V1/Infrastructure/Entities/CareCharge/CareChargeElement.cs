using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge
{
    public class CareChargeElement : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CareChargeId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int ClaimCollectorId { get; set; }
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
