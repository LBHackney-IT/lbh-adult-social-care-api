using System;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackagePlainResponse
    {
        public Guid Id { get; set; }
        public int PackageType { get; set; }
        public Guid ServiceUserId { get; set; }
        public int? SupplierId { get; set; }
        public int PrimarySupportReasonId { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public PackageStatus Status { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
    }
}
