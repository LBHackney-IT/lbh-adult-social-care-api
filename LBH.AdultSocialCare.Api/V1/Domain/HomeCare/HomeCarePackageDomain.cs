using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCare
{
    public class HomeCarePackageDomain
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
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updater Id
        /// </summary>
        public Guid? UpdaterId { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Id
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Object
        /// </summary>
        public PackageStatusOption Status { get; set; }

        /// <summary>
        /// Gets or sets the Stage Id
        /// </summary>
        public int? StageId { get; set; }

        /// <summary>
        /// Gets or sets the Stage Object
        /// </summary>
        public StageDomain Stage { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Id
        /// </summary>
        public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Object
        /// </summary>
        public SupplierDomain Supplier { get; set; }

        public IEnumerable<HomeCarePackageClaimCreationDomain> PackageReclaims { get; set; }
    }
}
