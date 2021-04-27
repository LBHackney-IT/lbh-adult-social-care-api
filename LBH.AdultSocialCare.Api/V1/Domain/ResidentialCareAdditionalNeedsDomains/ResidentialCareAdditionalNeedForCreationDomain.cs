using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareAdditionalNeedsDomains
{
    public class ResidentialCareAdditionalNeedForCreationDomain
    {
        public bool IsWeeklyCost { get; set; }
        public bool IsOneOffCost { get; set; }
        public string NeedToAddress { get; set; }
        public Guid CreatorId { get; set; }
    }
}
