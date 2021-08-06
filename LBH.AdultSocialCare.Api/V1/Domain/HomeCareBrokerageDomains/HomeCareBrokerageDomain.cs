using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareDomains;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains
{
    public class HomeCareBrokerageDomain
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public HomeCarePackageDomain HomeCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public IEnumerable<HomeCarePackageCostDomain> HomeCarePackageCost { get; set; }
    }
}
