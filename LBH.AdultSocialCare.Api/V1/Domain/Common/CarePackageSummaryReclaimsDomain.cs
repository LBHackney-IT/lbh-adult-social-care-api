using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackageSummaryReclaimsResponse))]
    public class CarePackageSummaryReclaimsDomain
    {
        public decimal Fnc { get; set; }
        public decimal CareCharge { get; set; }
        public decimal SubTotal { get; set; }
    }
}
