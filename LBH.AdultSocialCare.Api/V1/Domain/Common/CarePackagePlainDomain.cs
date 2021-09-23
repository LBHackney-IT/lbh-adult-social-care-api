using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackagePlainResponse))]
    [GenerateListMappingFor(typeof(CarePackagePlainResponse))]
    public class CarePackagePlainDomain
    {
        public Guid Id { get; set; }
        public int PackageType { get; set; }
        public Guid ServiceUserId { get; set; }
        public int? SupplierId { get; set; }
        public string PrimarySupportReason { get; set; }
        public PackageStatus Status { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
    }
}
