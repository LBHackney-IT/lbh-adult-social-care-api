using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.V1.Infrastructure.Entities
{
    public class Roles
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty("Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Role Name
        /// </summary>
        [JsonProperty("Role Name")]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the Service Name
        /// </summary>
        [JsonProperty("Sequence")]
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the Is Default
        /// </summary>
        [JsonProperty("Is Default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        [JsonProperty("Creator Id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        [JsonProperty("Date Created")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        [JsonProperty("Updator Id")]
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        [JsonProperty("Date Updated")]
        public DateTime? DateUpdated { get; set; }

        [NotMapped]
        public bool Success { get; set; }

        [NotMapped]
        public string Message { get; set; }
    }
}
