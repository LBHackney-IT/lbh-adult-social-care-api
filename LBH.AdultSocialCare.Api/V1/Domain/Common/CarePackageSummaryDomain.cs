using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CarePackageSummaryDomain
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string PackageType { get; set; }
        public string PrimarySupportReason { get; set; }

        public SupplierDomain Supplier { get; set; }
        public ClientsDomain ServiceUser { get; set; }
        public CarePackageSettingsDomain Settings { get; set; }

        public IEnumerable<CarePackageDetailDomain> AdditionalWeeklyNeeds { get; set; }
        public IEnumerable<CarePackageDetailDomain> AdditionalOneOffNeeds { get; set; }

        public decimal AdditionalWeeklyCost { get; set; }
        public decimal AdditionalOneOffCost { get; set; }

        public decimal CostOfPlacement { get; set; }
        public decimal? FncPayment { get; set; }
        public decimal SubTotalCost { get; set; }
        public decimal TotalWeeklyCost { get; set; }

        public CarePackageReclaimDomain FundedNursingCare { get; set; }
        public IEnumerable<CarePackageReclaimDomain> CareCharges { get; set; }

        public CarePackageSummaryReclaimsDomain HackneyReclaims { get; set; }
        public CarePackageSummaryReclaimsDomain SupplierReclaims { get; set; }
    }
}
