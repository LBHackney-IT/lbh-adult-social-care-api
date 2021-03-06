using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageListItemResponse
    {
        public Guid CarePackageId { get; set; }
        public string PackageStatus { get; set; }
        public string ClientName { get; set; }
        public DateTimeOffset ClientDateOfBirth { get; set; }
        public int HackneyId { get; set; }
        public string PostCode { get; set; }
        public string AssignedBrokerName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
