using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request
{

    public class HomeCarePackageRequest
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
        /// Gets or sets a value indicating whether this instance is this an immediate service.
        /// </summary>
        public bool IsThisAnImmediateService { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is this client under S117.
        /// </summary>
        public bool IsThisClientUnderS117 { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Id
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the Stage Id
        /// </summary>
        public int? StageId { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Id
        /// </summary>
        public int? SupplierId { get; set; }

        public IEnumerable<HomeCarePackageClaimCreationRequest> PackageReclaims { get; set; }

    }

}
