using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Response
{
    public class HomeCareBrokerageCreationResponse
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public IEnumerable<HomeCarePackageCostResponse> HomeCarePackageCost { get; set; }
    }
}
