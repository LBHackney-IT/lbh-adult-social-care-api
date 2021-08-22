using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request
{
    public class HomeCareBrokerageCreationRequest
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public IEnumerable<HomeCarePackageCostCreationRequest> HomeCarePackageCost { get; set; }
    }
}
