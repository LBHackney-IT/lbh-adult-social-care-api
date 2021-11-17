using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackage))]
    [GenerateMappingFor(typeof(CarePackagePlainResponse))]
    [GenerateListMappingFor(typeof(CarePackage))]
    [GenerateListMappingFor(typeof(CarePackagePlainResponse))]
    public class CarePackagePlainDomain
    {
        public Guid Id { get; set; }
        public int PackageType { get; set; }
        public Guid ServiceUserId { get; set; }
        public int? SupplierId { get; set; }
        public int PrimarySupportReasonId { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public PackageStatus Status { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
    }
}
