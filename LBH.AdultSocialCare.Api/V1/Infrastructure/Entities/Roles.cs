using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class Roles
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? DateUpdated { get; set; }
    }
}
