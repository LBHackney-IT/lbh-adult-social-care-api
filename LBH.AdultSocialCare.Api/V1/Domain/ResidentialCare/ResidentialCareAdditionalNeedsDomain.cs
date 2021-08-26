using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareAdditionalNeedsDomain
    {
        public Guid Id { get; set; }
        public Guid ResidentialCarePackageId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string AdditionalNeedsPaymentTypeName { get; set; }
        public string NeedToAddress { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
    }
}
