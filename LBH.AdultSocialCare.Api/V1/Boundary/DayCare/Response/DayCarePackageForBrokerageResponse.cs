using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response
{
    public class DayCarePackageForBrokerageResponse
    {
        public DayCareBrokeragePackageDetailsDto PackageDetails { get; set; }
        public ApproveClientDetailsDto ClientDetails { get; set; }
        public IEnumerable<DayCarePackageApprovalHistoryDto> PackageApprovalHistory { get; set; }
    }
}
