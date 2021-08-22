using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCare
{
    public class DayCarePackageForUpdateDomain
    {
        public Guid DayCarePackageId { get; set; }
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
        public Guid UpdaterId { get; set; }
        public int StatusId { get; set; }
    }
}
