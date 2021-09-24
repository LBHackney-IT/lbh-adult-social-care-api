using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CarePackageBrokerageDomain
    {
        public int? SupplierId { get; set; }

        public List<CarePackageDetailDomain> Details { get; set; }
    }
}
