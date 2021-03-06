using System;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Data.SeedConfiguration
{
    public class SupplierSeed : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new Supplier
            {
                Id = 1,
                SupplierName = "Abbeleigh House",
                Address = "Abbeleigh House",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 2,
                SupplierName = "Abbey Care Complex",
                Address = "Abbey Care Complex",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 3,
                SupplierName = "Acacia Lodge",
                Address = "Acacia Lodge [Cedar Site 0]",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 4,
                SupplierName = "Hc-One Limited",
                Address = "Hc-One Limited",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 5,
                SupplierName = "Acorn Lodge",
                Address = "Acorn Lodge",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 6,
                SupplierName = "Albany Nursing Home",
                Address = "Albany Nursing Home",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 7,
                SupplierName = "Manor Farm Care Home",
                Address = "Manor Farm Care Home",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 8,
                SupplierName = "Four Seasons Health Care",
                Address = "Four Seasons Health Care [Cedar Site 8] Lingfield Point",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 9,
                SupplierName = "The Hornchurch Care Home",
                Address = "The Hornchurch Care Home",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 10,
                SupplierName = "Bupa Care Homes",
                Address = "Bupa Care Homes [Cedar Site 10] Wynne Road",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
