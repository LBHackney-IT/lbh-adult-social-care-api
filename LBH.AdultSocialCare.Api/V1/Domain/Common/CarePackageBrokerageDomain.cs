using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackageBrokerageResponse))]
    public class CarePackageBrokerageDomain
    {
        public decimal CoreCost { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public int? SupplierId { get; set; }

        public List<CarePackageDetailDomain> Details { get; set; } = new List<CarePackageDetailDomain>();
    }
}
