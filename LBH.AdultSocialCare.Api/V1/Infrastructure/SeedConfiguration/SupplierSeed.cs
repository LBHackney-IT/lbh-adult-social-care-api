using System;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                SupplierName = "Furkan",
                IsSupplierInternal = true,
                HasSupplierFrameworkContractedRates = true,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
