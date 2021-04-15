using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{

    public class NursingCarePackage : BaseEntity
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
        /// Gets or sets the Clients
        /// </summary>
        [ForeignKey(nameof(ClientId))]
        public Clients Clients { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Is Interim
        /// </summary>
        public bool IsInterim { get; set; }

        /// <summary>
        /// Gets or sets the Is Expected Stay Over 8Weeks
        /// </summary>
        public bool IsUnder8Weeks { get; set; }

        /// <summary>
        /// Gets or sets the Is Expected Stay Over 52Weeks
        /// </summary>
        public bool IsUnder52Weeks { get; set; }

        /// <summary>
        /// Gets or sets the Is Long Stay
        /// </summary>
        public bool IsLongStay { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Nursing Home
        /// </summary>
        public string TypeOfNursingHome { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Status Id
        /// </summary>
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the Status Object
        /// </summary>
        public PackageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the NursingCareAdditionalNeeds
        /// </summary>
        public List<NursingCareAdditionalNeeds> NursingCareAdditionalNeeds { get; set; }

    }

}
