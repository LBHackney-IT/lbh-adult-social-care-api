using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Validations;

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

        public int SupplierId { get; set; }

        [Range(1, 4)]
        public ReclaimStatus Status { get; set; }

        [Range(1, 1)]
        public ReclaimType Type { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }

        public string AssessmentFileUrl { get; set; }
    }
}
