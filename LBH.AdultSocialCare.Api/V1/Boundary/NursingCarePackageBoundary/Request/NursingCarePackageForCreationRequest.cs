using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Request;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Request
{
    public class NursingCarePackageForCreationRequest
    {
        [Required] public bool? IsFixedPeriod { get; set; }
        [Required] public Guid? ClientId { get; set; }
        [Required] public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [Required] public bool? HasRespiteCare { get; set; }
        [Required] public bool? HasDischargePackage { get; set; }
        [Required] public bool? IsThisAnImmediateService { get; set; }
        [Required] public bool? IsThisUserUnderS117 { get; set; }
        [Required] public int? TypeOfStayId { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public int? TypeOfNursingCareHomeId { get; set; }
        [Required] public Guid? CreatorId { get; set; }
        public IEnumerable<NursingCareAdditionalNeedForCreationRequest> NursingCareAdditionalNeeds { get; set; }
    }
}
