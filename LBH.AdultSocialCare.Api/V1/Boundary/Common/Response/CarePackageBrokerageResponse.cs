using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CarePackageBrokerageResponse
    {
        public decimal CoreCost { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public int? SupplierId { get; set; }

        public List<CarePackageDetailResponse> Details { get; set; } = new List<CarePackageDetailResponse>();
    }
}
