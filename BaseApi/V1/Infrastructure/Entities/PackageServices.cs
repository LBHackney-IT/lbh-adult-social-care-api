using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Infrastructure.Entities
{
    /// <summary>
    /// Services object
    /// </summary>
    public class PackageServices
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Package Id
        /// </summary>
        [JsonProperty("Package Id")]
        public Guid PackageId { get; set; }

        /// <summary>
        /// Gets or sets the Package object
        /// </summary>
        [JsonProperty("Package")]
        public Package Package { get; set; }

        /// <summary>
        /// Gets or sets the Service Name
        /// </summary>
        [JsonProperty("Service Name")]
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        [JsonProperty("Creator Id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Date Updated")]
        public DateTime? DateUpdated { get; set; }

        [NotMapped]
        public bool Success { get; set; }

        [NotMapped]
        public string Message { get; set; }
    }
}
