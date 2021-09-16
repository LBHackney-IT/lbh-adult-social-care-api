using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    [GenerateMappingFor(typeof(CareChargeElementForUpdateDomain))]
    public class CareChargeElementForUpdateRequest
    {
        [Required, GuidNotEmpty] public Guid CareElementId { get; set; }
        [Required] public string ElementName { get; set; }
        [Range(1, int.MaxValue)] public int TypeId { get; set; }
        [RegularExpression(@"^([0-9]+)\d+\.\d{2}$")] [Range(0, 9999999999.99)] public decimal Amount { get; set; }
        [Range(1, int.MaxValue)] public int CollectorId { get; set; }
        [Required] public DateTimeOffset? StartDate { get; set; }
        [Required] public DateTimeOffset? EndDate { get; set; }
    }
}
