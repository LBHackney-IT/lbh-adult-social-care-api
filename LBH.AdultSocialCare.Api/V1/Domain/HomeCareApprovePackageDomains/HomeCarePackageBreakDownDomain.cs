using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareApprovePackageDomains
{
    public class HomeCarePackageBreakDownDomain
    {
        public double PersonalCareTotalHours { get; set; }

        public double EscortTotalHours { get; set; }

        public double DomesticTotalHours { get; set; }

        public double WakingNightsTotalHours { get; set; }

        public double SleepingNightsTotalHours { get; set; }

        public double NightOwlTotalHours { get; set; }
    }
}
