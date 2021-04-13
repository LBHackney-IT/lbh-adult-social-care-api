using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{

    public class Package : BaseEntity
    {

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Package Name
        /// </summary>
        [Required]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the Sequence
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

    }

}
