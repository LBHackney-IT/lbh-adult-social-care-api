using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCare
{
    public class HomeCareBrokerageCreationDomain
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public IEnumerable<HomeCarePackageCostCreationDomain> HomeCarePackageCost { get; set; }
    }
}
