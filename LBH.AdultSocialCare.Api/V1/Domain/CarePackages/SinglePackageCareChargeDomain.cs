using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class SinglePackageCareChargeDomain
    {
        public string PackageType { get; set; }
        public string CareChargeStatus { get; set; }
        public ServiceUserDomain ServiceUser { get; set; }
        public CarePackageSettingsDomain Settings { get; set; }
        public SupplierDomain Supplier { get; set; }
        public IEnumerable<CarePackageReclaimDomain> CareCharges { get; set; }
    }
}
