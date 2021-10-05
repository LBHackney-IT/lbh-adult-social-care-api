using HttpServices.Models.Features;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class BrokerPackageViewResponse
    {
        public IEnumerable<BrokerPackageItemResponse> Packages { get; set; }
        public Dictionary<string, int> StatusCount { get; set; }
        public PagingMetaData PagingMetaData { get; set; }
    }
}
