using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Collections.Generic;
using Common.Attributes;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(BrokerPackageViewResponse))]
    public class BrokerPackageViewDomain
    {
        public IEnumerable<BrokerPackageItemDomain> Packages { get; set; }
        public Dictionary<string, int> StatusCount { get; set; }
        public PagingMetaData PagingMetaData { get; set; }
    }
}
