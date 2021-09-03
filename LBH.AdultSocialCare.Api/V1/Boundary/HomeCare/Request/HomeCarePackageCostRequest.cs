using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request
{
    public class HomeCarePackageCostRequest
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        public Guid HomeCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Service Id
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the Cost Per Hour
        /// </summary>
        public decimal CostPerHour { get; set; }

        /// <summary>
        /// Gets or sets the Hour Per Week
        /// </summary>
        public int HoursPerWeek { get; set; }

        /// <summary>
        /// Gets or sets the Total Cost
        /// </summary>
        public decimal TotalCost { get; set; }
    }
}
