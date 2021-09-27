using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CarePackageBrokerageDomain
    {
        public decimal CoreCost { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public int? SupplierId { get; set; }

        public List<CarePackageDetailDomain> Details { get; set; } = new List<CarePackageDetailDomain>();
    }
}
