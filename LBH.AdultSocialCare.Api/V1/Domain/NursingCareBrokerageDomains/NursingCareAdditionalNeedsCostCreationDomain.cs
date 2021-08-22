using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains
{
    public class NursingCareAdditionalNeedsCostCreationDomain
    {
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
        public Guid CreatorId { get; set; }
    }
}
