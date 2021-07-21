using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Features;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ApprovedPackagesBoundary.Response
{
    public class PagedApprovedPackagesResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<ApprovedPackagesResponse> Data { get; set; }
    }
}
