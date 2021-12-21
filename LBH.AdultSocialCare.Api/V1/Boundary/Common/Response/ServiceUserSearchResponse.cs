using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Responses;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class ServiceUserSearchResponse
    {
        public PagedResponse<ResidentResponse> Residents { get; set; }
        public int totalCount { get; set; }
        public int? nextCursor { get; set; }
    }
}
