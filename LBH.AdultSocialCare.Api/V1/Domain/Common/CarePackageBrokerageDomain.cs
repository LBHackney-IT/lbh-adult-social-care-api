using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CarePackageBrokerageDomain
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public decimal Amount { get; set; }
        public IEnumerable<CarePackageElementDomain> CarePackageElements { get; set; }
    }
}
