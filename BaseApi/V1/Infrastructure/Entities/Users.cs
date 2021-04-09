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
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Middle Name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Hackney Id
        /// </summary>
        public int HackneyId { get; set; }

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets the Town of Users.
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Gets or sets the County
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the Post Code
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the Role Id
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the Role Object
        /// </summary>
        [ForeignKey(nameof(RoleId))]
        public Roles Roles { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTime? DateUpdated { get; set; }
    }
}
