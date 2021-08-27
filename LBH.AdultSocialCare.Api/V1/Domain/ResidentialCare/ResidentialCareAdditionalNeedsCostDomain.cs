using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareAdditionalNeedsCostDomain
    {
        public Guid ResidentialCareBrokerageId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string AdditionalNeedsPaymentTypeName { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
    }
}