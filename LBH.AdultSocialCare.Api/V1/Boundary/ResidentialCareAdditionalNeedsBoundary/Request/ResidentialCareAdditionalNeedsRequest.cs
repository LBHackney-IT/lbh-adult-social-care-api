using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Request
{
    public class ResidentialCareAdditionalNeedsRequest
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Weekly
        /// </summary>
        public bool IsWeeklyCost { get; set; }

        /// <summary>
        /// Gets or sets the One Off
        /// </summary>
        public bool IsOneOffCost { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }
    }
}
