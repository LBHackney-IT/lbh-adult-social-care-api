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

        [ForeignKey(nameof(ResidentialCarePackageId))]
        public ResidentialCarePackage ResidentialCarePackage { get; set; }
    }
}
