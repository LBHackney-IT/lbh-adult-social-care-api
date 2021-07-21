using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Features;

namespace LBH.AdultSocialCare.Api.V1.Boundary.BrokeredPackagesBoundary.Response
{
    public class PagedBrokeredPackagesResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<BrokeredPackagesResponse> Data { get; set; }
    }
}
