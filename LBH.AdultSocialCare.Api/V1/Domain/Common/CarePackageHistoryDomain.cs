using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CarePackageHistoryDomain
    {
        public DateTimeOffset DateCreated { get; set; }
        public string Description { get; set; }
        public string RequestMoreInformation { get; set; }
        public string UserRole { get; set; }
    }
}
