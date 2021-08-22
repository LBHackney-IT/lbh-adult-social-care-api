using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare
{
    public class ResidentialCareAdditionalNeed : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Residential Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        public int AdditionalNeedsPaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        [ForeignKey(nameof(ResidentialCarePackageId))]
        public ResidentialCarePackage ResidentialCarePackage { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public User Updater { get; set; }

        [ForeignKey(nameof(AdditionalNeedsPaymentTypeId))]
        public AdditionalNeedsPaymentType AdditionalNeedsPaymentType { get; set; }
    }
}
