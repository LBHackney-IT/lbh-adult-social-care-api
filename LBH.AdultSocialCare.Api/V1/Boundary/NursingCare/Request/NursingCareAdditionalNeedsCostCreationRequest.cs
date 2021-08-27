using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Validations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request
{
    public class NursingCareAdditionalNeedsCostCreationRequest
    {
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
    }
}
