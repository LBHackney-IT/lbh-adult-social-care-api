using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
{
    public class BrokerPackageViewQueryParameters : RequestParameters
    {
        public Guid? ServiceUserId { get; set; }
        public PackageStatus? Status { get; set; }
        public Guid? BrokerId { get; set; }
        public DateTimeOffset? FromDate { get; set; }
        public DateTimeOffset? ToDate { get; set; }
    }
}
