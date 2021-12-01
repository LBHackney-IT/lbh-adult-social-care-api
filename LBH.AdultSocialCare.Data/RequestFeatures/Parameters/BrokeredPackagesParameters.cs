using System;

namespace LBH.AdultSocialCare.Data.RequestFeatures.Parameters
{
    public class BrokeredPackagesParameters : RequestParameters
    {
        public int? HackneyId { get; set; }
        public string ClientName { get; set; }
        public int? PackageTypeId { get; set; }
        public Guid? SocialWorkerId { get; set; }
        public int? StageId { get; set; }
    }
}
