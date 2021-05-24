using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageReclaimBoundary.Request;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Request.ResidentialCare
{
    public class ResidentialCarePackageForCreationRequest
    {
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
        [Required] public Guid? CreatorId { get; set; }
        public IEnumerable<ResidentialCareAdditionalNeedForCreationRequest> ResidentialCareAdditionalNeeds { get; set; }
        public IEnumerable<ResidentialCarePackageClaimCreationRequest> PackageReclaims { get; set; }
    }
}
