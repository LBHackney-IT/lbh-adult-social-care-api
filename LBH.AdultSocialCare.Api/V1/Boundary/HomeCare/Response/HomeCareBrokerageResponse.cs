using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response
{
    public class HomeCareBrokerageResponse
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public HomeCarePackageResponse HomeCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public IEnumerable<HomeCarePackageCostResponse> HomeCarePackageCost { get; set; }
    }
}
