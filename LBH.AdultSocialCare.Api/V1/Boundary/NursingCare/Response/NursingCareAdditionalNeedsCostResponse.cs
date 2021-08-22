using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response
{
    public class NursingCareAdditionalNeedsCostResponse
    {
        public Guid NursingCareAdditionalNeedsCostId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string AdditionalNeedsPaymentTypeName { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
    }
}
