using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCare
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
