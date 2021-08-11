using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Request
{

    public class HomeCareServiceRequest
    {

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Package Id
        /// </summary>
        public Guid PackageId { get; set; }

        /// <summary>
        /// Gets or sets the Service Name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTimeOffset? DateUpdated { get; set; }

    }

}
