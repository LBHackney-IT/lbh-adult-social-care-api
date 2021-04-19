using System;

namespace LBH.AdultSocialCare.Api.V1.Domain
{
    public class RolesDomain
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
        /// Gets or sets the Service Name
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the Is Default
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTimeOffset? DateUpdated { get; set; }
    }
}
