using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains
{
    public class ResidentialCareTypeOfStayOptionDomain
    {
        public int TypeOfStayOptionId { get; set; }

        public string OptionName { get; set; }

        public string OptionPeriod { get; set; }
    }
}
