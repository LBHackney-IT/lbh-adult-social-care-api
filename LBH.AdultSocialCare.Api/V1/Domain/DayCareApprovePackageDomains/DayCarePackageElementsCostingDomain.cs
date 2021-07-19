using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCareApprovePackageDomains
{
    public class DayCarePackageElementsCostingDomain
    {
        public decimal DayCareCentre { get; set; }

        public decimal Transport { get; set; }

        public decimal AdditionalNeeds { get; set; }
    }
}
