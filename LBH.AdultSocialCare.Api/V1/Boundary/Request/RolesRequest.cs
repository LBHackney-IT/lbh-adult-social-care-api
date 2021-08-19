using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Request
{
    public class RolesRequest
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Role Name
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the Is Default
        /// </summary>
        public bool IsDefault { get; set; }

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
