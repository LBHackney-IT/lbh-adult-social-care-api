using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Features;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class PagedCareChargePackagesResponse
    {
        public PagingMetaData PagingMetaData { get; set; }
        public IEnumerable<CareChargePackagesResponse> Data { get; set; }
    }
}
