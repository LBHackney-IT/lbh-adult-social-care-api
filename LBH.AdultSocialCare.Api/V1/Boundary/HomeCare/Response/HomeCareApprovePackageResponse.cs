using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response
{
    public class HomeCareApprovePackageResponse
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public HomeCarePackageResponse HomeCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Hours Per Week
        /// </summary>
        public double HoursPerWeek { get; set; }

        /// <summary>
        /// Gets or sets the Cost Of Care
        /// </summary>
        public decimal CostOfCare { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Break Down
        /// </summary>
        public HomeCarePackageBreakDownResponse HomeCarePackageBreakDown { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updater Id
        /// </summary>
        public Guid? UpdaterId { get; set; }
    }
}
