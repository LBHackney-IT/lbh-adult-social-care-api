using Microsoft.AspNetCore.Http;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CareChargeReclaimFileDomain
    {
        public IFormFile AssessmentFile { get; set; }
        public Guid AssessmentFileId { get; set; }
    }
}
