using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCareApprovePackageDomains
{
    public class DayCarePackageBreakDownDomain
    {
        public double DayCareHours { get; set; }

        public double TransportHours { get; set; }

        public double DayOpportunitiesHours { get; set; }
    }
}
