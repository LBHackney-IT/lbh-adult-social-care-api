using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageHistoryResponse
    {
        public long Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string Description { get; set; }
        public string RequestMoreInformation { get; set; }
        public string CreatorName { get; set; }
    }
}
