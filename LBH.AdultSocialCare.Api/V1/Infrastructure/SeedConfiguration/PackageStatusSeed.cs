using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageStatusSeed : IEntityTypeConfiguration<PackageStatus>
    {
        public void Configure(EntityTypeBuilder<PackageStatus> builder)
        {
            builder.HasData(new PackageStatus
            {
                Id = 1,
                StatusName = "New",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new PackageStatus
            {
                Id = 2,
                StatusName = "Package Confirmation",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new PackageStatus
            {
                Id = 3,
                StatusName = "Approved For Brokerage",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new PackageStatus
            {
                Id = 4,
                StatusName = "Brokering",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new PackageStatus
            {
                Id = 5,
                StatusName = "Supplier Sourced",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new PackageStatus
            {
                Id = 6,
                StatusName = "Commercially Approved",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new PackageStatus
            {
                Id = 7,
                StatusName = "Contracted",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            });
        }
    }
}
