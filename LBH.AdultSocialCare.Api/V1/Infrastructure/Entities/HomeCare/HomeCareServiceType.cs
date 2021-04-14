using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare
{

    /// <summary>
    /// Services object
    /// </summary>
    public class HomeCareServiceType : BaseEntity
    {

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Service Name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the primary carer minutes.
        /// </summary>
        public ICollection<HomeCareServiceTypeMinutes> PrimaryCarerMinutes { get; set; }

        /// <summary>
        /// Gets or sets the secondary carer minutes.
        /// </summary>
        public ICollection<HomeCareServiceTypeMinutes> SecondaryCarerMinutes { get; set; }

    }

}
