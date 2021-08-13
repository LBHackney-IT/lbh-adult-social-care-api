using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class BaseEntityTmp : BaseEntity
    {
        /// <summary>
        /// Gets or sets identifier of the user who has created this entity.
        /// </summary>
        [Required]
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets identifier of the last user who has updated this entity.
        /// </summary>
        public Guid? UpdaterId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public User Updater { get; set; }
    }
}
