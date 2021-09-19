using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SinglePackageCareChargeDomain
    {
        public Guid CareChargeId { get; set; }
        public string CareChargeStatus { get; set; }
        public ClientsDomain Client { get; set; }
        public CarePackageDomain CarePackage { get; set; }
        public CarePackageBrokerageDomain CarePackageBrokerage { get; set; }
        public IEnumerable<CareChargeElementForSinglePackageDomain> CareChargeElements { get; set; }
    }
}
