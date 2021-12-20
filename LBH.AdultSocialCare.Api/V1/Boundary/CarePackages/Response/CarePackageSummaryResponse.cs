using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageSummaryResponse
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string PackageType { get; set; }
        public PackageStatus Status { get; set; }
        public string PrimarySupportReason { get; set; }
        public string SchedulingPeriod { get; set; }

        public SupplierDomain Supplier { get; set; }
        public ServiceUserDomain ServiceUser { get; set; }
        public CarePackageSettingsDomain Settings { get; set; }

        public IEnumerable<CarePackageDetailResponse> AdditionalWeeklyNeeds { get; set; }
        public IEnumerable<CarePackageDetailResponse> AdditionalOneOffNeeds { get; set; }

        public decimal AdditionalWeeklyCost { get; set; }
        public decimal AdditionalOneOffCost { get; set; }

        public decimal CostOfPlacement { get; set; }
        public decimal FncPayment { get; set; }
        public decimal SubTotalCost { get; set; }
        public decimal TotalWeeklyCost { get; set; }

        public CarePackageReclaimResponse FundedNursingCare { get; set; }
        public IEnumerable<CarePackageReclaimResponse> CareCharges { get; set; }

        public CarePackageSummaryReclaimsResponse HackneyReclaims { get; set; }
        public CarePackageSummaryReclaimsResponse SupplierReclaims { get; set; }
    }
}
