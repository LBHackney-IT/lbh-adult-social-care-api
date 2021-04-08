using System;

namespace BaseApi.V1.Boundary.Response
{
    public class RolesResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
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
