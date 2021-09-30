using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CarePackageResponse
    {
        public Guid CarePackageId { get; set; }
        public string PackageStatus { get; set; }
        public string ClientName { get; set; }
        public DateTimeOffset ClientDateOfBirth { get; set; }
        public string HackneyId { get; set; }
        public string PostCode { get; set; }
        public string AssignedBrokerName { get; set; }
        public string DateCreated { get; set; }
    }
}
