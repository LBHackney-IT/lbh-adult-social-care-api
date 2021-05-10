using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCareApproveBrokeredBoundary.Response
{
    public class DayCareApproveBrokeredResponse
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public DayCarePackageResponse DayCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Cost Of Care
        /// </summary>
        public decimal CostOfCare { get; set; }

        /// <summary>
        /// Gets or sets the Additional Needs Cost
        /// </summary>
        public decimal CostOfAdditionalNeeds { get; set; }

        /// <summary>
        /// Gets or sets the Cost Of Transport
        /// </summary>
        public decimal CostOfTransport { get; set; }

        /// <summary>
        /// Gets or sets the Total Per Week
        /// </summary>
        public decimal TotalPerWeek { get; set; }
    }
}