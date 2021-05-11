using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response
{
    public class DayCarePackageForApprovalDetailsResponse
    {
        public PackageDetailsDto PackageDetails { get; set; }
        public ClientDetailsDto ClientDetails { get; set; }
        public CostSummaryDto CostSummary { get; set; }
        public IEnumerable<PackageApprovalHistoryDto> PackageApprovalHistory { get; set; }
    }
}
