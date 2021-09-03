using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCare
{
    public class DayCareCollegeForCreationDomain
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

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid CreatorId { get; set; }
    }
}
