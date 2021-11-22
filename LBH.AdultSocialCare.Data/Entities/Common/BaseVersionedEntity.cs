using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Data.Entities.Common
{
    public abstract class BaseVersionedEntity : BaseEntity
    {
        public long Version { get; set; }

        /// <summary>
        /// Gets a list of properties, which, when changed, produce a new version of the entity.
        /// E.g. a change to DateUpdated typically is not meaningful, but change to a Cost is.
        /// </summary>
        [NotMapped]
        internal abstract IList<string> VersionedFields { get; }
    }
}
