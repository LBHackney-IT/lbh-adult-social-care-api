using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class BrokerPackageItemResponse
    {
        public string ServiceUserName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Address { get; set; }
        public string HackneyId { get; set; }
        public string PackageType { get; set; }
        public string PackageStatus { get; set; }
        public string BrokerName { get; set; }
        public DateTimeOffset DateAssigned { get; set; }
    }
}
