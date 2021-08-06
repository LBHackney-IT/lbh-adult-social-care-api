using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains
{
    public class NursingCareAdditionalNeedsDomain
    {
        public Guid Id { get; set; }

        public Guid NursingCarePackageId { get; set; }

        public bool IsWeeklyCost { get; set; }

        public bool IsOneOffCost { get; set; }
        public string NeedToAddress { get; set; }

        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
    }
}
