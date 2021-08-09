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
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = PackageTypesConstants.ResidentialCarePackageId,
                PackageType = PackageTypesConstants.ResidentialCarePackage,
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = PackageTypesConstants.DayCarePackageId,
                PackageType = PackageTypesConstants.DayCarePackage,
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = PackageTypesConstants.NursingCarePackageId,
                PackageType = PackageTypesConstants.NursingCarePackage,
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
