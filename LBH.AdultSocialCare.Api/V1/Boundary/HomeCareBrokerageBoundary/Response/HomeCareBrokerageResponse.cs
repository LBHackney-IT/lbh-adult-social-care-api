using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Response
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
