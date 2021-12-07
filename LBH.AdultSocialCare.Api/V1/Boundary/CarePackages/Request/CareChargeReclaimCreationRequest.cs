using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Validations;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    public class CareChargeReclaimCreationRequest
    {
        public Guid? Id { get; set; } // Reclaim Id if modifying

        [Required, GuidNotEmpty]
        public Guid CarePackageId { get; set; }

        [Required]
        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        [Required]
        [Range(1, 2)]
        public ClaimCollector ClaimCollector { get; set; }

        [Required]
        [Range(1, 3)]
        public ReclaimSubType SubType { get; set; }

        [Required] public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string ClaimReason { get; set; }
    }
}
