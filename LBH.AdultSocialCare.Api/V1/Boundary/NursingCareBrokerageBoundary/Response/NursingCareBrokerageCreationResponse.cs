using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response
{
    public class NursingCareBrokerageCreationResponse
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public IEnumerable<NursingCarePackageCostResponse> NursingCarePackageCost { get; set; }
    }
}
