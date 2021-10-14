using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Validations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    public class CareChargeReclaimCreationRequest
    {
        [Required, GuidNotEmpty]
        public Guid CarePackageId { get; set; }

        [Required]
        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        [Required]
        [Range(1, 2)]
        public ClaimCollector ClaimCollector { get; set; }

        public int SupplierId { get; set; }

        [Range(1, 4)]
        public ReclaimStatus Status { get; set; }

        [Required]
        [Range(1, 2)]
        public ReclaimType Type { get; set; }

        [Required]
        [Range(1, 3)]
        public ReclaimSubType SubType { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }

        public string ClaimReason { get; set; }
    }
}
