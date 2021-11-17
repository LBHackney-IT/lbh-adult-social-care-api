using System;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Data.RequestFeatures.Parameters
{
    public class BrokerPackageViewQueryParameters : RequestParameters
    {
        public Guid? ServiceUserId { get; set; }
        public string ServiceUserName { get; set; }
        public PackageStatus? Status { get; set; }
        public Guid? BrokerId { get; set; }
        public DateTimeOffset? FromDate { get; set; }
        public DateTimeOffset? ToDate { get; set; }
    }
}
