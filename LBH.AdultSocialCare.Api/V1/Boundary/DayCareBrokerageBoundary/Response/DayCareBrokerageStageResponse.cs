using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Response
{
    public class DayCareBrokerageStageResponse
    {
        public int PackageStatusId { get; set; }
        public string StatusName { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
        public int SequenceNumber { get; set; }
        public bool IsDayCareStatus { get; set; } = true;
        public bool IsStatusActive { get; set; } = true;
        public string Stage { get; set; }
        public string PackageAction { get; set; }
    }
}
