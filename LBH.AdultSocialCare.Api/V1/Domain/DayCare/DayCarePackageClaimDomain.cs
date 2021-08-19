using System;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCare
{
    public class DayCarePackageClaimDomain
    {
        public Guid DayCarePackageReclaimId { get; set; }
        public Guid DayCarePackageId { get; set; }
        public int ReclaimFromId { get; set; }
        public int ReclaimCategoryId { get; set; }
        public int ReclaimAmountOptionId { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }

        public ReclaimFromDomain ReclaimFrom { get; set; }

        public ReclaimCategoryDomain ReclaimCategory { get; set; }

        public ReclaimAmountOptionDomain ReclaimAmountOption { get; set; }
    }
}
