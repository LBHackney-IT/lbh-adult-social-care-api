using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class SinglePackageCareChargeResponse
    {
        public Guid CareChargeId { get; set; }
        public string CareChargeStatus { get; set; }
        public ClientsResponse Client { get; set; }
        public CarePackageResponse CarePackage { get; set; }
        public CarePackageBrokerageResponse CarePackageBrokerage { get; set; }
        public IEnumerable<CareChargeElementResponse> CareChargeElements { get; set; }
    }
}
