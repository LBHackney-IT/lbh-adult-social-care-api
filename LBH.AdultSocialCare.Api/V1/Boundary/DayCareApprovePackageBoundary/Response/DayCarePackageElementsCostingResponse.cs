using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCareApprovePackageBoundary.Response
{
    public class DayCarePackageElementsCostingResponse
    {
        public decimal DayCareCentre { get; set; }

        public decimal Transport { get; set; }

        public decimal AdditionalNeeds { get; set; }
    }
}
