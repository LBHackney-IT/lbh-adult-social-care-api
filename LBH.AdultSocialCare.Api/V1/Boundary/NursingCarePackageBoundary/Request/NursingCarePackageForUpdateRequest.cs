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
        [Required] public bool? HasRespiteCare { get; set; }
        [Required] public bool? HasDischargePackage { get; set; }
        [Required] public bool? IsThisAnImmediateService { get; set; }
        [Required] public bool? IsThisUserUnderS117 { get; set; }
        [Required] public int? TypeOfStayId { get; set; }
        [Required] public string NeedToAddress { get; set; }
        [Required] public int? TypeOfNursingCareHomeId { get; set; }
        [Required] public int? StatusId { get; set; }
        public int? SupplierId { get; set; }
        public int? StageId { get; set; }
        public Guid? AssignedUserId { get; set; }
    }
}
