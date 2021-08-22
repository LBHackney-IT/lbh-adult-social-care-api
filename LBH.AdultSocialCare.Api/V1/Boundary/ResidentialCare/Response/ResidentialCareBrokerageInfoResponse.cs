using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response
{
    public class ResidentialCareBrokerageInfoResponse
    {
        /// <summary>
        /// Gets or sets the Residential Care Brokerage Id
        /// </summary>
        public Guid ResidentialCareBrokerageId { get; set; }

        /// <summary>
        /// Gets or sets the Residential Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Residential Care Package
        /// </summary>
        public ResidentialCarePackageResponse ResidentialCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Residential Core Per Week
        /// </summary>
        public decimal ResidentialCore { get; set; }

        public IEnumerable<ResidentialCareAdditionalNeedsCostResponse> ResidentialCareAdditionalNeedsCosts { get; set; }

        /// <summary>
        /// Gets or sets the package brokerage stage id.
        /// </summary>
        public int? StageId { get; set; }

        /// <summary>
        /// Gets or sets the brokerage supplier.
        /// </summary>
        public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public Guid? UpdatorId { get; set; }
    }
}
