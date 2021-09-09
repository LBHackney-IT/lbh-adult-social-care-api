using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CareChargeElementCreationResponse
    {
        public int Id { get; set; }
        public int CareChargeId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int ClaimCollectorId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
