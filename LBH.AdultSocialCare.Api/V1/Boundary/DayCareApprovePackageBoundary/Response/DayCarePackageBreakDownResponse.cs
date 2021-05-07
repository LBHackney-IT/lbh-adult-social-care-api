using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCareApprovePackageBoundary.Response
{
    public class DayCarePackageBreakDownResponse
    {
        public double DayCareHours { get; set; }

        public double TransportHours { get; set; }

        public double DayOpportunitiesHours { get; set; }
    }
}
