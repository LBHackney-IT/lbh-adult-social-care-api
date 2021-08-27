using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareAdditionalNeedForCreationDomain
    {
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string NeedToAddress { get; set; }
        public Guid CreatorId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
