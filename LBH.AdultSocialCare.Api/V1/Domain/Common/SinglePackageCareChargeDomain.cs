using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SinglePackageCareChargeDomain
    {
        public string PackageType { get; set; }
        public string CareChargeStatus { get; set; }
        public ClientsDomain ServiceUser { get; set; }
        public CarePackageSettingsDomain Settings { get; set; }
        public SupplierDomain Supplier { get; set; }
        public IEnumerable<CarePackageReclaimDomain> CareCharges { get; set; }
    }
}
