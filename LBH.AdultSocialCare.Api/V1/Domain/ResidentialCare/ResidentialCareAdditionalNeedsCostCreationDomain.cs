using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareAdditionalNeedsCostCreationDomain
    {
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
    }
}