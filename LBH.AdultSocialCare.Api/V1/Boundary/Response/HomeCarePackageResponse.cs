using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Response
{
    public class HomeCarePackageResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Client
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

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
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTimeOffset? DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Id
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Object
        /// </summary>
        public PackageStatus Status { get; set; }
    }
}
