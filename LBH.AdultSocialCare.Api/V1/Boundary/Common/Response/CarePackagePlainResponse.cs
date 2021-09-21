using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CarePackagePlainResponse
    {
        public Guid Id { get; set; }
        public int PackageType { get; set; }
        public Guid ServiceUserId { get; set; }
        public int? SupplierId { get; set; }
        public string PrimarySupportReason { get; set; }
        public string PackagingScheduling { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public PackageStatusEnum Status { get; set; }
        public PackageStageEnum Stage { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
    }
}
