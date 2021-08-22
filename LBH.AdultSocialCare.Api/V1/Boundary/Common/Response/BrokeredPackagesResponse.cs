using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class BrokeredPackagesResponse
    {
        public Guid PackageId { get; set; }
        public Guid ServiceUserId { get; set; }
        public string ServiceUser { get; set; }
        public int PackageTypeId { get; set; }
        public string PackageType { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string Stage { get; set; }
        public Guid OwnerId { get; set; }
        public string Owner { get; set; }
        public int HackneyId { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public int DaysSinceApproval { get; set; }
    }
}
