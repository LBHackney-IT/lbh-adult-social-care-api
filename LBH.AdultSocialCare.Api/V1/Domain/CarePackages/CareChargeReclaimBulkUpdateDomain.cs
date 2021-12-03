using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CareChargeReclaimBulkUpdateDomain
    {
        public IFormFile AssessmentFile { get; set; }
        public Guid AssessmentFileId { get; set; }
        public List<CarePackageReclaimUpdateDomain> Reclaims { get; set; }
    }
}
