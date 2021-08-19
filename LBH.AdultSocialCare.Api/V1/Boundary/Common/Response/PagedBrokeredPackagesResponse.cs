using System.Collections.Generic;
using HttpServices.Models.Features;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class PagedBrokeredPackagesResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<BrokeredPackagesResponse> Data { get; set; }
    }
}
