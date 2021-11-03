using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class FundedNursingCareCreationRequest
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
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string AssessmentFileUrl { get; set; }
    }
}
