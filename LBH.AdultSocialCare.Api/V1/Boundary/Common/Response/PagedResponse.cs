using System.Collections.Generic;
using HttpServices.Models.Features;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class PagedResponse<TResponse>
    {
        public PagingMetaData PagingMetaData { get; set; }

        public IEnumerable<TResponse> Data { get; set; }
    }
}
