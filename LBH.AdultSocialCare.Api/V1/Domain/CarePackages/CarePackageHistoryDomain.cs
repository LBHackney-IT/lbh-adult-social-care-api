using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageHistoryResponse))]
    [GenerateListMappingFor(typeof(CarePackageHistoryResponse))]
    public class CarePackageHistoryDomain
    {
        public long Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string Description { get; set; }
        public string RequestMoreInformation { get; set; }
        public string CreatorName { get; set; }
    }
}
