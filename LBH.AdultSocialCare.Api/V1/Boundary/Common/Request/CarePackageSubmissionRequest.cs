using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    [GenerateMappingFor(typeof(CarePackageSubmissionDomain))]
    public class CarePackageSubmissionRequest
    {
        [Required]
        public Guid? ApproverId { get; set; }

        public string Notes { get; set; }
    }
}
