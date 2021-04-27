using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class NursingCareAdditionalNeed : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Care Package Id
        /// </summary>
        public Guid NursingCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Weekly
        /// </summary>
        public bool IsWeeklyCost { get; set; }

        /// <summary>
        /// Gets or sets the One Off
        /// </summary>
        public bool IsOneOffCost { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updater Id
        /// </summary>
        public Guid? UpdaterId { get; set; }

        [ForeignKey(nameof(NursingCarePackageId))]
        public NursingCarePackage NursingCarePackage { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public User Updater { get; set; }
    }
}