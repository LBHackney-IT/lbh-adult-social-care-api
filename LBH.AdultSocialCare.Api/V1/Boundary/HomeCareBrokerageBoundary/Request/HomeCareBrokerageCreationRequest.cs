using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Request
{
    public class HomeCareBrokerageCreationRequest
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public IEnumerable<HomeCarePackageCostCreationRequest> HomeCarePackageCost { get; set; }
    }
}
