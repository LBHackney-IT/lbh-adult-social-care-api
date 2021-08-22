using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class ApprovedPackagesResponse
    {
        public Guid PackageId { get; set; }
        public Guid ServiceUserId { get; set; }
        public string ServiceUser { get; set; }
        public int PackageTypeId { get; set; }
        public string PackageType { get; set; }
        public decimal CareValue { get; set; }
        public string Approver { get; set; }
        public string SubmittedBy { get; set; }
        public int HackneyId { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
    }
}
