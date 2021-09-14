using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    [GenerateMappingFor(typeof(CareChargeElementPlainDomain))]
    [GenerateListMappingFor(typeof(CareChargeElementPlainDomain))]
    public class CareChargeElementCreationRequest
    {
        [Required]
        public Guid CareChargeId { get; set; }

        public int? StatusId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public int ClaimCollectorId { get; set; }

        public string Name { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }
    }
}
