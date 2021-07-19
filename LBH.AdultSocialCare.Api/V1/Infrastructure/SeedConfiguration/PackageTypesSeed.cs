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
                Id = 1,
                PackageType = "Home Care Package",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = 2,
                PackageType = "Residential Care Package",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = 3,
                PackageType = "Day Care Package",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Package
            {
                Id = 4,
                PackageType = "Nursing Care Package",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
