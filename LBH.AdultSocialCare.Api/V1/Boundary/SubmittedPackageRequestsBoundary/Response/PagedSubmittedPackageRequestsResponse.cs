using HttpServices.Models.Features;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.SubmittedPackageRequestsBoundary.Response
{
    public class PagedSubmittedPackageRequestsResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<SubmittedPackageRequestsResponse> Data { get; set; }
    }
}
