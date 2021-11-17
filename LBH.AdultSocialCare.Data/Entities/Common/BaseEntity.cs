using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Data.Entities.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateCreated = DateTimeOffset.UtcNow;
            DateUpdated = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Gets or sets the date added.
        /// </summary>
        // public DateTimeOffset DateCreated { get; private set; }
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets identifier of the user who has created this entity.
        /// </summary>
        [Required]
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets identifier of the last user who has updated this entity.
        /// </summary>
        public Guid? UpdaterId { get; set; }

        /// <summary>
        /// Gets or sets a User object representing a creator of this entity.
        /// </summary>
        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }

        /// <summary>
        /// Gets or sets a User object representing a last updater of this entity.
        /// </summary>
        [ForeignKey(nameof(UpdaterId))]
        public User Updater { get; set; }
    }
}
