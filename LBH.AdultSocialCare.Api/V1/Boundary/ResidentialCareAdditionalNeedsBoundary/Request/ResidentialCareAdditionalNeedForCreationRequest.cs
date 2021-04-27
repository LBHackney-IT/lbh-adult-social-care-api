using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Request
{
    public class ResidentialCareAdditionalNeedForCreationRequest
    {
        public bool IsWeeklyCost { get; set; }
        public bool IsOneOffCost { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public Guid? CreatorId { get; set; }
    }
}
