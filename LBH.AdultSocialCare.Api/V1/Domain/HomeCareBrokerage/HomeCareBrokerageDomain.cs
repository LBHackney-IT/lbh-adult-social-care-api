using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage
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
