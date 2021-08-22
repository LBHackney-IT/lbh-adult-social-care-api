using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareBrokerageBoundary.Request
{
    public class ResidentialCareBrokerageCreationRequest
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
        public DateTimeOffset StartDate { get; set; }

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
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }
    }
}
