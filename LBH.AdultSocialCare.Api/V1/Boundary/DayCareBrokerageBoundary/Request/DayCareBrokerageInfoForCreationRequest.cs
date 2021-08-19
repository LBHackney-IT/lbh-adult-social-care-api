using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Request
{
    public class DayCareBrokerageInfoForCreationRequest
    {
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
    }
}
