using System.Collections.Generic;
using HttpServices.Models.Features;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class PagedApprovedPackagesResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<ApprovedPackagesResponse> Data { get; set; }
    }
}
