using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
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

        public int AdditionalNeedsPaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        [ForeignKey(nameof(NursingCarePackageId))]
        public NursingCarePackage NursingCarePackage { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }

        [ForeignKey(nameof(AdditionalNeedsPaymentTypeId))]
        public AdditionalNeedsPaymentType AdditionalNeedsPaymentType { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public User Updater { get; set; }
    }
}
