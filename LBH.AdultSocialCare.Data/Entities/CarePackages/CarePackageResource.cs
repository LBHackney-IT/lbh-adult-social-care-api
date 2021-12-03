using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Data.Entities.CarePackages
{
    public class CarePackageResource : BaseEntity
    {
        public Guid Id { get; set; }
        public PackageResourceType Type { get; set; }
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public Guid FileId { get; set; }
        public Guid PackageId { get; set; }

        [ForeignKey(nameof(PackageId))]
        public CarePackage Package { get; set; }
    }
}
