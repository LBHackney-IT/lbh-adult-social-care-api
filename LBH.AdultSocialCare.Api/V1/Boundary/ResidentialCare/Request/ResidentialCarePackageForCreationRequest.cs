using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request
{
    public class ResidentialCarePackageForCreationRequest
    {
        [Required] public bool? IsFixedPeriod { get; set; }
        [Required] public Guid? ClientId { get; set; }
        [Required] public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [Required] public bool? HasRespiteCare { get; set; }
        [Required] public bool? HasDischargePackage { get; set; }
        [Required] public bool? IsThisAnImmediateService { get; set; }
        [Required] public bool? IsThisUserUnderS117 { get; set; }
        [Required] public int? ResidentialCareTypeOfStayId { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public int? TypeOfResidentialCareHomeId { get; set; }
        public IEnumerable<ResidentialCareAdditionalNeedForCreationRequest> ResidentialCareAdditionalNeeds { get; set; }
        public IEnumerable<ResidentialCarePackageClaimCreationRequest> PackageReclaims { get; set; }
    }
}
