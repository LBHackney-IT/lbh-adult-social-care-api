using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCare
{
    public class NursingCareAdditionalNeedForCreationDomain
    {
        public bool IsWeeklyCost { get; set; }
        public bool IsOneOffCost { get; set; }
        public string NeedToAddress { get; set; }
        public Guid CreatorId { get; set; }
    }
}
