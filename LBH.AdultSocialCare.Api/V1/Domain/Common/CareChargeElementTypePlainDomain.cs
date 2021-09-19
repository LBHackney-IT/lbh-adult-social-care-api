using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CareChargeElementTypePlainResponse))]
    [GenerateListMappingFor(typeof(CareChargeElementTypePlainResponse))]
    public class CareChargeElementTypePlainDomain
    {
        public int Id { get; set; }
        public string OptionName { get; set; }
    }
}
