using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApprovePackageBoundary.Response
{
    public class ResidentialCareApprovePackageResponse
    {
        /// <summary>
        /// Gets or sets the Residential Care package
        /// </summary>
        public ResidentialCarePackageResponse ResidentialCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Cost Of Care
        /// </summary>
        public decimal CostOfCare { get; set; }

        /// <summary>
        /// Gets or sets the Additional Needs Cost
        /// </summary>
        public decimal CostOfAdditionalNeeds { get; set; }

        /// <summary>
        /// Gets or sets the One Off Cost
        /// </summary>
        public decimal CostOfOneOff { get; set; }

        /// <summary>
        /// Gets or sets the Total Per Week
        /// </summary>
        public decimal TotalPerWeek { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public Guid? UpdatorId { get; set; }
    }
}
