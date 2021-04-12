using System;

namespace LBH.AdultSocialCare.Api.V1.Domain
{
    public class StatusDomain
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Status Name
        /// </summary>
        public string StatusName { get; set; }

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
