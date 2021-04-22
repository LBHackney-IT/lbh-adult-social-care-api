using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Request
{
    public class NursingCarePackageForUpdateRequest
    {
        [Required] public Guid? ClientId { get; set; }
        [Required] public bool? IsFixedPeriod { get; set; }
        [Required] public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [Required] public bool? IsRespiteCare { get; set; }
        [Required] public bool? IsDischargePackage { get; set; }
        [Required] public bool? IsThisAnImmediateService { get; set; }
        [Required] public bool? IsThisUserUnderS117 { get; set; }
        [Required] public int? TypeOfStayId { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public int? TypeOfNursingCareHomeId { get; set; }
        [Required] public Guid? UpdaterId { get; set; }
        [Required] public int? StatusId { get; set; }
    }
}
