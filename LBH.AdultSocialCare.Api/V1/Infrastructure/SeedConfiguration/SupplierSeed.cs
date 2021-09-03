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
