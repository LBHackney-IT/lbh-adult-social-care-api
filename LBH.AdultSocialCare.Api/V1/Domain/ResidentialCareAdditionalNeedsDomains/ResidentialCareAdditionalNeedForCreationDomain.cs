using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareAdditionalNeedsDomains
{
    public class ResidentialCareAdditionalNeedForCreationDomain
    {
        public bool? IsWeeklyCost { get; set; }
        public bool? IsOneOffCost { get; set; }
        public bool? IsFixedPeriod { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NeedToAddress { get; set; }
        public Guid CreatorId { get; set; }
    }
}
