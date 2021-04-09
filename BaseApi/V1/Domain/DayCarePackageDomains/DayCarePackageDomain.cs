using System;

namespace BaseApi.V1.Domain.DayCarePackageDomains
{
    public class DayCarePackageDomain
    {
        public Guid DayCarePackageId { get; set; }
        public Guid PackageId { get; set; }
        public Guid ClientId { get; set; }
        public bool IsFixedPeriodOrOngoing { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool IsThisAnImmediateService { get; set; }
        public bool IsThisUserUnderS117 { get; set; }
        public string NeedToAddress { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool TransportNeeded { get; set; }
        public bool EscortNeeded { get; set; }
        public int TermTimeConsiderationOptionId { get; set; }
        public string HowLong { get; set; }
        public string HowManyTimesPerMonth { get; set; } // Daily, weekly, monthly
        public string OpportunitiesNeedToAddress { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;
        public Guid CreatorId { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public Guid? UpdaterId { get; set; }
        public Guid StatusId { get; set; }

        public string PackageName { get; set; }
        public string ClientName { get; set; }
        public string TermTimeConsiderationOptionName { get; set; }
        public string CreatorName { get; set; }
        public string UpdaterName { get; set; }
        public string StatusName { get; set; }
    }
}
