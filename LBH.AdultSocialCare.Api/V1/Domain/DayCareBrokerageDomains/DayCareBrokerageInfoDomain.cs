using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains
{
    public class DayCareBrokerageInfoDomain
    {
        public Guid DayCarePackageId { get; set; }
        public int CorePackageSupplierId { get; set; }
        public int CorePackageDaysPerWeek { get; set; }
        public decimal CorePackageCostPerDay { get; set; }
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
    }
}
