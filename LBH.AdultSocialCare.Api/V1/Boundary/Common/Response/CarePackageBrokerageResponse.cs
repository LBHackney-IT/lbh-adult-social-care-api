using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CarePackageBrokerageResponse
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public decimal Amount { get; set; }
        public IEnumerable<CarePackageElementResponse> CarePackageElements { get; set; }
    }
}
