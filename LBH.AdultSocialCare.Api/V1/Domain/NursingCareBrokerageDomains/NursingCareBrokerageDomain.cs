using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains
{
    public class NursingCareBrokerageDomain
    {
        /// <summary>
        /// Gets or sets the Nursing Care package
        /// </summary>
        public NursingCarePackageDomain NursingCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Care package
        /// </summary>
        public NursingCarePackageCostDomain NursingCarePackageCost { get; set; }
    }
}
