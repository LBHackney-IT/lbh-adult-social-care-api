using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class SinglePackageCareChargeResponse
    {
        public string PackageType { get; set; }
        public string CareChargeStatus { get; set; }
        public ServiceUserResponse ServiceUser { get; set; }
        public CarePackageSettingsResponse Settings { get; set; }
        public SupplierResponse Supplier { get; set; }
        public IEnumerable<CarePackageReclaimResponse> CareCharges { get; set; }
    }
}
