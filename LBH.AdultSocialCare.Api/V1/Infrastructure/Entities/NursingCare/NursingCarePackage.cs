using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class NursingCarePackage : BaseEntity
    {
        public NursingCarePackage()
        {
            NursingCareAdditionalNeeds = new HashSet<NursingCareAdditionalNeed>();
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

        /// <summary>
        /// Gets or sets the Type Of Nursing Home
        /// </summary>
        [ForeignKey(nameof(TypeOfNursingCareHomeId))]
        public TypeOfNursingCareHome TypeOfCareHome { get; set; }

        [ForeignKey(nameof(TypeOfStayId))]
        public NursingCareTypeOfStayOption TypeOfStayOption { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public ServiceUser Creator { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public ServiceUser Updater { get; set; }

        /// <summary>
        /// Gets or sets the NursingCareAdditionalNeed
        /// </summary>
        public virtual ICollection<NursingCareAdditionalNeed> NursingCareAdditionalNeeds { get; set; }
        public virtual ICollection<NursingCarePackageReclaim> PackageReclaims { get; set; }
    }
}
