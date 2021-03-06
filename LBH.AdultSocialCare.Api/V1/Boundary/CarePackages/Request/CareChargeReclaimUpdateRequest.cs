using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateListMappingFor(typeof(CarePackageReclaimUpdateDomain))]
    public class CareChargeReclaimUpdateRequest
    {
        [Required, GuidNotEmpty]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        [Required]
        [Range(1, 2)]
        public ClaimCollector ClaimCollector { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string ClaimReason { get; set; }
        public IFormFile AssessmentFile { get; set; }
        public Guid AssessmentFileId { get; set; }
    }
}
