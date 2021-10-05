using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class BrokerPackageViewDomain
    {
        public string ServiceUserName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Address { get; set; }
        public string MosaicId { get; set; }
        public string PackageType { get; set; }
        public string PackageStatus { get; set; }
        public string BrokerName { get; set; }
        public DateTimeOffset DateAssigned { get; set; }
        public Dictionary<string, int> StatusCount { get; set; }
    }
}
