using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage
{
    public class DayCareBrokerageInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BrokerageInfoId { get; set; }

        [Required] public Guid DayCarePackageId { get; set; }
        [Required] public int CorePackageSupplierId { get; set; }
        [Required] public int CorePackageDaysPerWeek { get; set; }
        [Required] public decimal CorePackageCostPerDay { get; set; }
        public int? TransportSupplierId { get; set; }
        public int? TransportDaysPerWeek { get; set; }
        public decimal? TransportCostPerDay { get; set; }
        public int? TransportEscortSupplierId { get; set; }
        public int? TransportEscortHoursPerWeek { get; set; }
        public decimal? TransportEscortCostPerWeek { get; set; }
        public int? DayCareOpportunitiesSupplierId { get; set; }
        public int? DayCareOpportunitiesHoursPerWeek { get; set; }
        public decimal? DayCareOpportunitiesCostPerHour { get; set; }
        public int? EscortSupplierId { get; set; }
        public int? EscortHoursPerWeek { get; set; }
        public decimal? EscortCostPerHour { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }

        [ForeignKey(nameof(DayCarePackageId))] public DayCarePackage DayCarePackage { get; set; }
        [ForeignKey(nameof(CorePackageSupplierId))] public Supplier CorePackageSupplier { get; set; }
        [ForeignKey(nameof(TransportSupplierId))] public Supplier TransportSupplier { get; set; }
        [ForeignKey(nameof(TransportEscortSupplierId))] public Supplier TransportEscortSupplier { get; set; }
        [ForeignKey(nameof(DayCareOpportunitiesSupplierId))] public Supplier DayCareOpportunitiesSupplier { get; set; }
        [ForeignKey(nameof(EscortSupplierId))] public Supplier EscortSupplier { get; set; }
        [ForeignKey(nameof(CreatorId))] public User Creator { get; set; }
        [ForeignKey(nameof(UpdaterId))] public User Updater { get; set; }
    }
}
