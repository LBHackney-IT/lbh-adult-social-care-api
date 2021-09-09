using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
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
