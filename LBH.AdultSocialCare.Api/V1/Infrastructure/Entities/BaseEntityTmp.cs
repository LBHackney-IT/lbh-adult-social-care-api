using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class BaseEntityTmp : BaseEntity
    {
        /// <summary>
        /// Gets or sets identifier of the user who has created this entity.
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets identifier of the last user who has updated this entity.
        /// </summary>
        public Guid? UpdaterId { get; set; }
    }
}
