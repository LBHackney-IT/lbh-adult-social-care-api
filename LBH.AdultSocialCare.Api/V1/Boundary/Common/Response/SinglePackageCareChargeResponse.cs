using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class SinglePackageCareChargeResponse
    {
        public string PackageType { get; set; }
        public string CareChargeStatus { get; set; }
        public ClientsResponse ServiceUser { get; set; }
        public CarePackageSettingsResponse Settings { get; set; }
        public SupplierResponse Supplier { get; set; }
        public IEnumerable<CarePackageReclaimResponse> CareCharges { get; set; }
    }
}
