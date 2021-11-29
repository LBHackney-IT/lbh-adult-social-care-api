using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CareChargeReclaimBulkUpdateDomain
    {
        public IFormFile AssessmentFile { get; set; }
        public Guid AssessmentFileId { get; set; }
        public List<CarePackageReclaimUpdateDomain> Reclaims { get; set; }
    }
}
