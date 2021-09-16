using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response
{
    public class NursingCareAdditionalNeedsCostResponse
    {
        public Guid NursingCareAdditionalNeedsId { get; set; }
        public Guid NursingCareAdditionalNeedsCostId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string AdditionalNeedsPaymentTypeName { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
    }
}
