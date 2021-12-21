using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageSummaryResponse))]
    public class CarePackageSummaryDomain
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

        public IEnumerable<CarePackageDetailDomain> AdditionalWeeklyNeeds { get; set; }
        public IEnumerable<CarePackageDetailDomain> AdditionalOneOffNeeds { get; set; }

        public decimal AdditionalWeeklyCost { get; set; }
        public decimal OneOffCost { get; set; }

        public decimal CostOfPlacement { get; set; }
        public decimal FncPayment { get; set; }
        public decimal TotalCostOfPlacement { get; set; }
        public decimal TotalWeeklyCost { get; set; }

        public CarePackageReclaimDomain FundedNursingCare { get; set; }
        public IEnumerable<CarePackageReclaimDomain> CareCharges { get; set; }

        public CarePackageSummaryReclaimsDomain HackneyReclaims { get; set; }
        public CarePackageSummaryReclaimsDomain SupplierReclaims { get; set; }
    }
}
