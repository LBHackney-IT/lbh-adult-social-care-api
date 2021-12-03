using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CareChargesCreateDomain
    {
        public IFormFile AssessmentFile { get; set; }
        public IList<CareChargeReclaimCreationDomain> CareCharges { get; set; }
    }
}
