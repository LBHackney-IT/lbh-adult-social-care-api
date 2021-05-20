using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ReclaimsDomains;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageReclaimDomains
{
    public class NursingCarePackageClaimDomain
    {
        public Guid NursingCarePackageReclaimId { get; set; }
        public Guid NursingCarePackageId { get; set; }
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
