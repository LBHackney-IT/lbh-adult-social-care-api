using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Boundary.Response
{
    public class HomeCarePackageResponse
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
        /// Gets or sets the Package
        /// </summary>
        public Package Package { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Clients
        /// </summary>
        public Clients Clients { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Is Fixed Period
        /// </summary>
        public bool IsFixedPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Is Ongoing Period
        /// </summary>
        public bool IsOngoingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Is This An Immediate Service
        /// </summary>
        public bool IsThisAnImmediateService { get; set; }

        /// <summary>
        /// Gets or sets the Is This An Immediate Service
        /// </summary>
        public bool IsThisuserUnderS117 { get; set; }

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

        /// <summary>
        /// Gets or sets the Status Id
        /// </summary>
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the Status Object
        /// </summary>
        public Status Status { get; set; }
    }
}
