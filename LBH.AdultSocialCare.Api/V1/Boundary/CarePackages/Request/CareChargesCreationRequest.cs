using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CareChargesCreateDomain))]
    public class CareChargesCreationRequest
    {
        public IFormFile AssessmentFile { get; set; }
        public IList<CareChargeReclaimCreationRequest> CareCharges { get; set; }
    }
}
