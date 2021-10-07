using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class SupplierSeed : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new Supplier
            {
                Id = 1,
                PackageTypeId = 1,
                SupplierName = "ABC Limited",
                Address = "15 Atherden Rd, Lower Clapton, London E5 0QP",
                IsSupplierInternal = true,
                HasSupplierFrameworkContractedRates = true,
                FundedNursingCareCollector = null,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Supplier
            {
                Id = 2,
                SupplierName = "XYZ Ltd",
                Address = "54 Crown Street, Belgravia, London WC1E 9YP",
                PackageTypeId = 1,
                IsSupplierInternal = true,
                HasSupplierFrameworkContractedRates = true,
                FundedNursingCareCollector = null,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
