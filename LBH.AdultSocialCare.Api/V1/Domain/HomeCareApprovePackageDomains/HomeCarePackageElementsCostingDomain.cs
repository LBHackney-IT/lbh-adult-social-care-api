using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareApprovePackageDomains
{
    public class HomeCarePackageElementsCostingDomain
    {
        public decimal PrimaryCarer { get; set; }

        public decimal SecondaryCarer { get; set; }

        public decimal Escort { get; set; }

        public decimal Domestic { get; set; }

        public decimal WakingNights { get; set; }

        public decimal SleepingNights { get; set; }

        public decimal NightOwl { get; set; }
    }
}
