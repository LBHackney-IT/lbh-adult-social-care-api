using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage
{
    public class HomeCareBrokerageElementDomain
    {
        public int ElementId { get; set; }

        // Primary Carer, Secondary Carer, Domestic Carer etc.
        public string ElementName { get; set; }
    }
}
