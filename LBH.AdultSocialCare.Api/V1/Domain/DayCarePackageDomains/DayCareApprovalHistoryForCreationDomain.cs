using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains
{
    public class DayCareApprovalHistoryForCreationDomain
    {
        public Guid DayCarePackageId { get; set; }
        public Guid CreatorId { get; set; }
        public int PackageStatusId { get; set; }
        public string LogText { get; set; }
        public string LogSubText { get; set; }
        public string CreatorRole { get; set; }
    }
}
