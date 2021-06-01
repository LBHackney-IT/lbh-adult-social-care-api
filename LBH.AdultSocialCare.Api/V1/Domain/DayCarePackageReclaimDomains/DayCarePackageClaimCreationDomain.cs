using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageReclaimDomains
{
    public class DayCarePackageClaimCreationDomain
    {
        public Guid DayCarePackageId { get; set; }
        public int ReclaimFromId { get; set; }
        public int ReclaimCategoryId { get; set; }
        public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
    }
}
