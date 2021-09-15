using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    [GenerateMappingFor(typeof(EndCareChargeElementDomain))]
    public class EndCareChargeElementRequest
    {
        [Required] public DateTimeOffset? NewEndDate { get; set; }
    }
}
