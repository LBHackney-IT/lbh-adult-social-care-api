using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCare
{
    public class HomeCarePackageClaimCreationDomain
    {
        public Guid HomeCarePackageId { get; set; }
        public int ReclaimFromId { get; set; }
        public int ReclaimCategoryId { get; set; }
        public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
    }
}
