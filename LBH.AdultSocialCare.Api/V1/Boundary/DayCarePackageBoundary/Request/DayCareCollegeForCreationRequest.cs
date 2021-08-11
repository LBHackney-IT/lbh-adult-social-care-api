using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request
{
    public class DayCareCollegeForCreationRequest
    {
        /// <summary>
        /// Gets or sets the College Name
        /// </summary>
        public string CollegeName { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset EndDate { get; set; }
    }
}
