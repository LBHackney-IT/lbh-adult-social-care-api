using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApproveBrokeredBoundary.Response
{
    public class HomeCareApproveBrokeredResponse
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
        /// Gets or sets the Home Care Package Elements Costing
        /// </summary>
        public HomeCarePackageElementsCostingResponse HomeCarePackageElementsCosting { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }
    }
}
