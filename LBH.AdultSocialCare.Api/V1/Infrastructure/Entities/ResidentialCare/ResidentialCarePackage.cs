using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare
{
    public class ResidentialCarePackage : BaseEntity
    {
        public ResidentialCarePackage()
        {
            ResidentialCareAdditionalNeeds = new HashSet<ResidentialCareAdditionalNeed>();
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
        /// Gets or sets the Client
        /// </summary>
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

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
        /// Gets or sets a value indicating whether this instance has respite care.
        /// </summary>
        public bool HasRespiteCare { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has discharge package.
        /// </summary>
        public bool HasDischargePackage { get; set; }

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
        public int? TypeOfResidentialCareHomeId { get; set; }

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
        [ForeignKey(nameof(TypeOfResidentialCareHomeId))]
        public TypeOfResidentialCareHome TypeOfCareHome { get; set; }

        [ForeignKey(nameof(TypeOfStayId))]
        public ResidentialCareTypeOfStayOption TypeOfStayOption { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public User Updater { get; set; }

        /// <summary>
        /// Gets or sets the NursingCareAdditionalNeed
        /// </summary>
        public virtual ICollection<ResidentialCareAdditionalNeed> ResidentialCareAdditionalNeeds { get; set; }

        public virtual ICollection<ResidentialCarePackageReclaim> PackageReclaims { get; set; }
    }
}
