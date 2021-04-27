using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarepackageBoundary.Request
{
    public class ResidentialCarePackageForUpdateRequest
    {
        [Required] public Guid? ClientId { get; set; }
        [Required] public bool? IsFixedPeriod { get; set; }
        [Required] public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [Required] public bool? HasRespiteCare { get; set; }
        [Required] public bool? HasDischargePackage { get; set; }
        [Required] public bool? IsThisAnImmediateService { get; set; }
        [Required] public bool? IsThisUserUnderS117 { get; set; }
        [Required] public int? TypeOfStayId { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public int? TypeOfResidentialCareHomeId { get; set; }
        [Required] public Guid? UpdaterId { get; set; }
        [Required] public int? StatusId { get; set; }
    }
}