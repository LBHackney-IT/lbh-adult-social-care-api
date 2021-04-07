using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.V1.Infrastructure.Entities
{
    /// <summary>
    /// User object for domain
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty("Id")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the First Name
        /// </summary>
        [JsonProperty("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Middle Name
        /// </summary>
        [JsonProperty("Middle Name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name
        /// </summary>
        [JsonProperty("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Hackney Id
        /// </summary>
        [JsonProperty("Hackney Id")]
        public int HackneyId { get; set; }

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        [JsonProperty("Address Line 1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        [JsonProperty("Address Line 2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        [JsonProperty("Address Line 3")]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets the Town of Users.
        /// </summary>
        [JsonProperty("Town")]
        public string Town { get; set; }

        /// <summary>
        /// Gets or sets the County
        /// </summary>
        [JsonProperty("County")]
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the Post Code
        /// </summary>
        [JsonProperty("PostCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the Role Id
        /// </summary>
        [JsonProperty("RoleId")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the Role Object
        /// </summary>
        [JsonProperty("Roles")]
        [ForeignKey(nameof(RoleId))]
        public Roles Roles { get; set; }

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
