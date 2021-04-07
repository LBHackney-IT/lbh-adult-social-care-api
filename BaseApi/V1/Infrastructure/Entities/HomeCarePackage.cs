using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.V1.Infrastructure.Entities
{
    public class HomeCarePackage
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
        /// Gets or sets the Package
        /// </summary>
        [JsonProperty("Package")]
        public Package Package { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        [JsonProperty("Client Id")]
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Clients
        /// </summary>
        [JsonProperty("Clients")]
        [ForeignKey(nameof(ClientId))]
        public Clients Clients { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Start Date")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("End Date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Is Fixed Period
        /// </summary>
        [JsonProperty("Is Fixed Period")]
        public bool IsFixedPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Is Ongoing Period
        /// </summary>
        [JsonProperty("Is Ongoing Period")]
        public bool IsOngoingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Is This An Immediate Service
        /// </summary>
        [JsonProperty("Is This An Immediate")]
        public bool IsThisAnImmediateService { get; set; }

        /// <summary>
        /// Gets or sets the Is This An Immediate Service
        /// </summary>
        [JsonProperty("Is This An Immediate")]
        public bool IsThisuserUnderS117 { get; set; }

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
        [JsonProperty("Date Updated")]
        public DateTime? DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the Status Id
        /// </summary>
        [JsonProperty("StatusId")]
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the Status Object
        /// </summary>
        [JsonProperty("Status")]
        public Status Status { get; set; }

        [NotMapped]
        public bool Success { get; set; }

        [NotMapped]
        public string Message { get; set; }
    }
}
