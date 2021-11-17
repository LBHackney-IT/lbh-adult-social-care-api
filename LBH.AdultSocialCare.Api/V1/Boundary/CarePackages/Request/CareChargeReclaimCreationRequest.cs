using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Data.Constants.Enums;

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

        [Required]
        [Range(1, 3)]
        public ReclaimSubType SubType { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string ClaimReason { get; set; }
    }
}
