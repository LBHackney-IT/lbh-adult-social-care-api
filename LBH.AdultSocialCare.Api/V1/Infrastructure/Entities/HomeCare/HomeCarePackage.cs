using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare
{

    public class HomeCarePackage
    {

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Client
        /// </summary>
        [ForeignKey(nameof(ClientId))]
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
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Id
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Object
        /// </summary>
        public PackageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the Stage Id
        /// </summary>
        public int? StageId { get; set; }

        /// <summary>
        /// Gets or sets the Stage Object
        /// </summary>
        [ForeignKey(nameof(StageId))]
        public Stage Stage { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Id
        /// </summary>
        public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Object
        /// </summary>
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

    }

}
