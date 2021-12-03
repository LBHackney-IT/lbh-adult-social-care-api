using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CareChargesCreateDomain))]
    public class CareChargesCreationRequest
    {
        public IList<CareChargeReclaimCreationRequest> CareCharges { get; set; }
    }
}
