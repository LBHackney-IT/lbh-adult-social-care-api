using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(SubTotalReclaimResponse))]
    public class SubTotalReclaimDomain
    {
        public decimal Fnc { get; set; }
        public decimal CareCharge { get; set; }
        public decimal SubTotal { get; set; }
    }
}
