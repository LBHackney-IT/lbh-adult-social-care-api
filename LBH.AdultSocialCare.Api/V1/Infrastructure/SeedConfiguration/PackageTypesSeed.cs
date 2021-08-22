using System;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageTypesSeed : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new Package
            {
                Id = PackageTypesConstants.HomeCarePackageId,
                PackageType = PackageTypesConstants.HomeCarePackage,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = PackageTypesConstants.ResidentialCarePackageId,
                PackageType = PackageTypesConstants.ResidentialCarePackage,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = PackageTypesConstants.DayCarePackageId,
                PackageType = PackageTypesConstants.DayCarePackage,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = PackageTypesConstants.NursingCarePackageId,
                PackageType = PackageTypesConstants.NursingCarePackage,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
