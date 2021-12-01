using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.Attributes;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CarePackageSubmissionDomain))]
    public class CarePackageSubmissionRequest
    {
        [Required]
        public Guid? ApproverId { get; set; }

        public string Notes { get; set; }
    }
}
