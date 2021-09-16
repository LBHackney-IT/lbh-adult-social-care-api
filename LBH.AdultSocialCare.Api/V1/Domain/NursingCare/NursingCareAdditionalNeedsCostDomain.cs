using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCare
{
    public class NursingCareAdditionalNeedsCostDomain
    {
        public Guid NursingCareBrokerageId { get; set; }
        public Guid NursingCareAdditionalNeedsId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string AdditionalNeedsPaymentTypeName { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
    }
}
