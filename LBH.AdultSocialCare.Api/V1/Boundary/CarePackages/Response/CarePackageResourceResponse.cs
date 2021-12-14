using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageResourceResponse
    {
        public Guid Id { get; set; }
        public PackageResourceType Type { get; set; }
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public Guid FileId { get; set; }
        public Guid PackageId { get; set; }
        public string TypeName => Type.GetDisplayName() ?? string.Empty;
    }
}
