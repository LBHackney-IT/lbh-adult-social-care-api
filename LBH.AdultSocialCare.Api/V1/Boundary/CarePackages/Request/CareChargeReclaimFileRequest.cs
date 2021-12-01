using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using Microsoft.AspNetCore.Http;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CareChargeReclaimFileDomain))]
    public class CareChargeReclaimFileRequest
    {
        public IFormFile AssessmentFile { get; set; }
        public Guid AssessmentFileId { get; set; }
    }
}
