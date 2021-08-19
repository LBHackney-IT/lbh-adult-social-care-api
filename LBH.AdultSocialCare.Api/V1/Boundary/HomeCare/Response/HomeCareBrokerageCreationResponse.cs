using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response
{
    public class HomeCareBrokerageCreationResponse
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public IEnumerable<HomeCarePackageCostResponse> HomeCarePackageCost { get; set; }
    }
}
