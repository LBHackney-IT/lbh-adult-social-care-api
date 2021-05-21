using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response
{
    public class NursingCareBrokerageResponse
    {
        /// <summary>
        /// Gets or sets the Nursing Care package
        /// </summary>
        public NursingCarePackageResponse NursingCarePackage { get; set; }
    }
}
