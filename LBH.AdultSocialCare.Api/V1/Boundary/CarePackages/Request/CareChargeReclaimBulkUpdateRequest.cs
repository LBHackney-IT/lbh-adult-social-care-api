using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    public class CareChargeReclaimBulkUpdateRequest
    {
        public IFormFile AssessmentFile { get; set; }
        public Guid AssessmentFileId { get; set; }
        public List<CareChargeReclaimUpdateRequest> Reclaims { get; set; }
    }
}
