using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageResource))]
    [GenerateListMappingFor(typeof(CarePackageResource))]
    [GenerateMappingFor(typeof(CarePackageResourceResponse))]
    [GenerateListMappingFor(typeof(CarePackageResourceResponse))]
    public class CarePackageResourceDomain
    {
        public Guid Id { get; set; }
        public PackageResourceType Type { get; set; }
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public Guid FileId { get; set; }
        public Guid PackageId { get; set; }
    }
}
