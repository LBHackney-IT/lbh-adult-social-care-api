using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class CareChargeElementCreationRequest
    {
        [Required]
        public int CareChargeId { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        public int StatusId { get; set; }

        [Required]
        public int TypeId { get; set; }

        public string Name { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }
    }
}
