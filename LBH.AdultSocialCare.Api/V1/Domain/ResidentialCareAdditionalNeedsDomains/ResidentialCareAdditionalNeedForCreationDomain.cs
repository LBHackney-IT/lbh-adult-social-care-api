using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareAdditionalNeedsDomains
{
    public class ResidentialCareAdditionalNeedForCreationDomain
    {
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string NeedToAddress { get; set; }
        public Guid CreatorId { get; set; }
    }
}
