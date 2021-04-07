using BaseApi.V1.Infrastructure.Entities;
using System;

namespace BaseApi.V1.Boundary.Response
{
    public class ServiceResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Package Id
        /// </summary>
        public Guid PackageId { get; set; }

        /// <summary>
        /// Gets or sets the Package object
        /// </summary>
        public Package Package { get; set; }

        /// <summary>
        /// Gets or sets the Service Name
        /// </summary>
        public string ServiceName { get; set; }

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

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
