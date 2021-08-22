using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Request
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
