using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCarePackageClaimCreationDomain
    {
        public Guid ResidentialCarePackageId { get; set; }
        public int ReclaimFromId { get; set; }
        public int ReclaimCategoryId { get; set; }
        public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
    }
}
