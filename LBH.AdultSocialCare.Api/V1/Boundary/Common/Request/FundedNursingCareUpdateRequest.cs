using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class FundedNursingCareUpdateRequest
    {
        [Required, GuidNotEmpty]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        [Range(1, 2)]
        public ClaimCollector ClaimCollector { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string AssessmentFileUrl { get; set; }
    }
}
