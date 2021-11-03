using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
{
    public class ApprovableCarePackagesQueryParameters : RequestParameters
    {
        public Guid? ServiceUserId { get; set; }
        public string ServiceUserName { get; set; }

        public Guid? ApproverId { get; set; }

        public PackageType? PackageType { get; set; }
        public PackageStatus? PackageStatus { get; set; }

        public DateTimeOffset? FromDate { get; set; }
        public DateTimeOffset? ToDate { get; set; }
    }
}
