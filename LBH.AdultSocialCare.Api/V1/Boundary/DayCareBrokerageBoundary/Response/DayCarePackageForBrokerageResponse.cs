using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Response
{
    public class DayCarePackageForBrokerageResponse
    {
        public DayCareBrokeragePackageDetailsDto PackageDetails { get; set; }
        public ApproveClientDetailsDto ClientDetails { get; set; }
        public IEnumerable<DayCarePackageApprovalHistoryDto> PackageApprovalHistory { get; set; }
    }
}
