using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request
{
    public class ResidentialCareBrokerageForCreationRequest
    {
        /// <summary>
        /// Gets or sets the Residential Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Id
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Stage Id
        /// </summary>
        public int StageId { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Residential Core Per Week
        /// </summary>
        public decimal ResidentialCore { get; set; }

        public IEnumerable<ResidentialCareAdditionalNeedsCostCreationRequest> ResidentialCareAdditionalNeedsCosts { get; set; }

        /// <summary>
        /// True if package has care charges and false otherwise. If true, provide care charge settings in request
        /// </summary>
        [Required] public bool? HasCareCharges { get; set; }

        /// <summary>
        /// If package has care charges, set claimed by and reason if relevant on this object
        /// </summary>
        public BrokerageCareChargeForChangeRequest CareChargeSettings { get; set; }
    }
}
