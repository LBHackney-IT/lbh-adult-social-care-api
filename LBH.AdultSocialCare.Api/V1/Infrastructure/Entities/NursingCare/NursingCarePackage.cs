using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class NursingCarePackage : BaseEntity
    {
        public NursingCarePackage()
        {
            NursingCareAdditionalNeeds = new HashSet<NursingCareAdditionalNeeds>();
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        public Guid? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Clients
        /// </summary>
        [ForeignKey(nameof(ClientId))]
        public Clients Clients { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fixed period.
        /// </summary>
        public bool IsFixedPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is respite care.
        /// </summary>
        public bool IsRespiteCare { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is discharge package.
        /// </summary>
        public bool IsDischargePackage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is this an immediate service.
        /// </summary>
        public bool IsThisAnImmediateService { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is this user under S117.
        /// </summary>
        public bool IsThisUserUnderS117 { get; set; }

        /// <summary>
        /// Gets or sets the type of stay identifier.
        /// </summary>
        public int? TypeOfStayId { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Nursing Home Id
        /// </summary>
        public int? TypeOfNursingCareHomeId { get; set; }

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
        [ForeignKey(nameof(StatusId))]
        public PackageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Nursing Home
        /// </summary>
        [ForeignKey(nameof(TypeOfNursingCareHomeId))]
        public TypeOfNursingCareHome TypeOfCareHome { get; set; }

        [ForeignKey(nameof(TypeOfStayId))]
        public NursingCareTypeOfStayOption TypeOfStayOption { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public Users Creator { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public Users Updater { get; set; }

        /// <summary>
        /// Gets or sets the NursingCareAdditionalNeeds
        /// </summary>
        public virtual ICollection<NursingCareAdditionalNeeds> NursingCareAdditionalNeeds { get; set; }
    }
}
